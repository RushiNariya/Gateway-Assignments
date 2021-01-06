using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManagement.Models;
using ProductManagement.ViewModels;
using PagedList;
using ProductManagement.Exceptions;
using ProductManagement.ExceptionHandling;
using log4net;
using System.Net.Http;
using Newtonsoft.Json;

namespace ProductManagement.Controllers
{
    //ProductsController MVC controller
    [ProductExceptionHandler]
    public class ProductsController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ProductsController));

        private ProductContext _context;

        public ProductsController()
        {
            _context = new ProductContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: List of Products
        public ActionResult Index(string option, string search, int? pageNumber, string sort)
        {
            Log.Debug("Product list is accessed by the admin.");

            //If the sort parameter is null or empty then initializing the value as Descending name  
            ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending name" : "";

            //If the sort value is gender then initializing the value as Descending gender  
            ViewBag.SortByCotegory = sort == "Cotegory" ? "descending Cotegory" : "Cotegory";

            var records = _context.Products.AsQueryable();

            if (option == "Cotegory")
            {
                //Return a view with a product records for user defined Product Cotegory
                records = records.Include(p => p.Category).Where(p => p.Category.Name.Contains(search) || search == null);
            }
            else
            {
                //Return a view with a product records for user defined Product Name
                records = records.Include(p => p.Category).Where(p => p.Name.Contains(search) || search == null);
            }

            switch (sort)
            {
                case "descending name":
                    records = records.OrderByDescending(p => p.Name);
                    break;

                case "descending Cotegory":
                    records = records.OrderByDescending(p => p.Category.Name);
                    break;

                case "Cotegory":
                    records = records.OrderBy(p => p.Category.Name);
                    break;

                default:
                    records = records.OrderBy(p => p.Name);
                    break;
            }

            Log.Info("Product list is passed to the view.");

            return View(records.ToPagedList(pageNumber ?? 1, 6));
        }

        //GET: New Product
        public ActionResult NewProduct()
        {
            Log.Debug("New product Form page is accessed by admin.");

            var categories = _context.Categories.ToList();
            var viewModel = new ProductCategoryViewModel()
            {
                Product = new Product(),
                Categories = categories
            };

            return View(viewModel);
        }

        //POST: New Product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product)
        {
            Log.Debug("New Product is submitted by the admin.");

            string smallImageName = Path.GetFileNameWithoutExtension(product.SmallImage.FileName);
            string extension = Path.GetExtension(product.SmallImage.FileName);
            smallImageName = smallImageName + DateTime.Now.ToString("yymmssfff") + extension;
            product.SmallImagePath = "~/Image/SmallImage/" + smallImageName;
            ModelState["product.SmallImagePath"].Errors.Clear();

            if (!ModelState.IsValid)
            {
                var viewModel = new ProductCategoryViewModel()
                {
                    Categories = _context.Categories.ToList(),
                    Product = product
                };
                return View("NewProduct", viewModel);
            }

            smallImageName = Path.Combine(Server.MapPath("~/Image/SmallImage/"), smallImageName);
            product.SmallImage.SaveAs(smallImageName);

            if (product.LargeImage != null)
            {
                string largeImageName = Path.GetFileNameWithoutExtension(product.LargeImage.FileName);
                extension = Path.GetExtension(product.LargeImage.FileName);
                largeImageName = largeImageName + DateTime.Now.ToString("yymmssfff") + extension;
                product.LargeImagePath = "~/Image/LargeImage/" + largeImageName;
                largeImageName = Path.Combine(Server.MapPath("~/Image/LargeImage/"), largeImageName);
                product.LargeImage.SaveAs(largeImageName);
            }

            Product temp = new Product();
            temp.Name = product.Name;
            temp.CategoryId = product.CategoryId;
            temp.Price = product.Price;
            temp.Quantity = product.Quantity;
            temp.Short_Desc = product.Short_Desc;
            temp.Long_Desc = product.Long_Desc;
            temp.SmallImagePath = product.SmallImagePath;
            temp.LargeImagePath = product.LargeImagePath;

            //Calling WebApi ProductController PostProduct action Method 
            HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("Products", temp).Result;
            var message = response.Content.ReadAsAsync<string>().Result;

            if (message.Equals("success"))
            {
                TempData["New_Product"] = product.Name + ", Product Added Successfully.";
            }
            else
            {
                TempData["New_Product"] = "Error occured while creating new product";
            }

            Log.Info("New Product is added into database by the admin");

            return RedirectToAction("Index");
        }

        //GET: Edit Product
        public ActionResult Edit(int? id)
        {
            Log.Debug("Edit product Form page is accessed by admin.");

            if (id == null)
                return RedirectToAction("BadRequest", "Error");

            //Calling WebApi ProductController GetProduct action Method 
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Products/" + id.ToString()).Result;
            var product = response.Content.ReadAsAsync<Product>().Result;

            //User Defined ProductNotFoundException is thrown.
            if (product == null)
                throw new ProductNotFoundException("Product Not Found!!!");

            var viewModel = new ProductCategoryViewModel()
            {
                Product = product,
                Categories = _context.Categories.ToList()
            };

            return View(viewModel);
        }

        //POST: Edit Product
        [HttpPost]
        public ActionResult EditPost(Product product)
        {
            Log.Debug("Edited Product is submitted by the admin.");

            if (!ModelState.IsValid)
            {
                var viewModel = new ProductCategoryViewModel()
                {
                    Categories = _context.Categories.ToList(),
                    Product = product
                };
                return View("Edit", viewModel);
            }

            if (product.SmallImage != null && product.LargeImage != null)
            {
                string smallImageName = Path.GetFileNameWithoutExtension(product.SmallImage.FileName);
                string extension = Path.GetExtension(product.SmallImage.FileName);
                smallImageName = smallImageName + DateTime.Now.ToString("yymmssfff") + extension;
                product.SmallImagePath = "~/Image/SmallImage/" + smallImageName;
                smallImageName = Path.Combine(Server.MapPath("~/Image/SmallImage/"), smallImageName);
                product.SmallImage.SaveAs(smallImageName);

                string largeImageName = Path.GetFileNameWithoutExtension(product.LargeImage.FileName);
                extension = Path.GetExtension(product.LargeImage.FileName);
                largeImageName = largeImageName + DateTime.Now.ToString("yymmssfff") + extension;
                product.LargeImagePath = "~/Image/LargeImage/" + largeImageName;
                largeImageName = Path.Combine(Server.MapPath("~/Image/LargeImage/"), largeImageName);
                product.LargeImage.SaveAs(largeImageName);
            }
            else if (product.SmallImage != null && product.LargeImage == null)
            {
                string smallImageName = Path.GetFileNameWithoutExtension(product.SmallImage.FileName);
                string extension = Path.GetExtension(product.SmallImage.FileName);
                smallImageName = smallImageName + DateTime.Now.ToString("yymmssfff") + extension;
                product.SmallImagePath = "~/Image/SmallImage/" + smallImageName;
                smallImageName = Path.Combine(Server.MapPath("~/Image/SmallImage/"), smallImageName);
                product.SmallImage.SaveAs(smallImageName);
            }
            else if (product.SmallImage == null && product.LargeImage != null)
            {
                string largeImageName = Path.GetFileNameWithoutExtension(product.LargeImage.FileName);
                string extension = Path.GetExtension(product.LargeImage.FileName);
                largeImageName = largeImageName + DateTime.Now.ToString("yymmssfff") + extension;
                product.LargeImagePath = "~/Image/LargeImage/" + largeImageName;
                largeImageName = Path.Combine(Server.MapPath("~/Image/LargeImage/"), largeImageName);
                product.LargeImage.SaveAs(largeImageName);
            }

            Product temp = new Product();
            temp.Name = product.Name;
            temp.CategoryId = product.CategoryId;
            temp.Price = product.Price;
            temp.Quantity = product.Quantity;
            temp.Short_Desc = product.Short_Desc;
            temp.Long_Desc = product.Long_Desc;
            temp.SmallImagePath = product.SmallImagePath;
            temp.LargeImagePath = product.LargeImagePath;

            //Calling WebApi ProductController PutProduct action Method 
            HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("Products/" + product.Id, temp).Result;
            var message = response.Content.ReadAsAsync<string>().Result;

            if (message.Equals("updated"))
            {
                TempData["Update_Message"] = " " + product.Name + ", Product Updated Successfully.";
            }
            else
            {
                TempData["Update_Message"] = "Error occured while updating the product";
            }

            Log.Info("Edited Product is updated into database by the admin");

            return RedirectToAction("Index");
        }

        //GET: Delete Product
        public ActionResult Delete(int? id)
        {
            Log.Debug("product delete is submitted by admin.");

            if (id == null)
                return RedirectToAction("BadRequest", "Error");

            var product = _context.Products.Find(id);

            //User Defined ProductNotFoundException is thrown.
            if (product == null)
                throw new ProductNotFoundException("Product Not Found!!!");

            string productName = product.Name;
            string oldImagePath = Request.MapPath(product.SmallImagePath);

            //Calling WebApi ProductController DeleteProduct action Method 
            HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("Products/" + id.ToString()).Result;
            var message = response.Content.ReadAsAsync<string>().Result;

            if (message.Equals("deleted"))
            {
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

                TempData["Delete_Message"] = " " + productName + ", Product Deleted Successfully.";
                Log.Info("product with product Id : " + product.Id + " is deleted by admin.");
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Delete_Message"] = "Error occured while deleting the product";
                return View();
            }
        }

        //POST: Delete Multiple Products
        [HttpPost]
        public ActionResult MultipleDelete(FormCollection formCollection)
        {
            Log.Debug("Multiple product delete is submitted by admin.");

            string[] ProductIds = formCollection["Id"].Split(new char[] { ',' });
            string oldImagePath;

            foreach (string id in ProductIds)
            {
                var product = this._context.Products.Find(int.Parse(id));
                oldImagePath = Request.MapPath(product.SmallImagePath);

                //Calling WebApi ProductController DeleteProduct action Method 
                HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("Products/" + id.ToString()).Result;
                var message = response.Content.ReadAsAsync<string>().Result;

                if (message.Equals("deleted"))
                {
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                    
            }

            Log.Info( ProductIds.Length +" products deleted by admin.");

            TempData["Multi_Delete"] = " Products Deleted Successfully.";

            return RedirectToAction("Index");
        }

        //GET: Product Detail
        public ActionResult Details(int? id)
        {
            Log.Debug("product details is accessed by admin.");

            if (id == null)
                return RedirectToAction("BadRequest", "Error");

            //Calling WebApi ProductController GetProduct action Method 
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Products/" + id.ToString()).Result;
            var product = response.Content.ReadAsAsync<Product>().Result;

            if (product == null)
                throw new ProductNotFoundException("Product Not Found!!!");

            Log.Info("product details for product Id : " + product.Id + " is accessed by the admin.");

            return View(product);
        }
    }
}