using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductManagement.Controllers.Api
{
    //ProductController Api controller 
    public class ProductsController : ApiController
    {
        private ProductContext _context;

        public ProductsController()
        {
            _context = new ProductContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> products = _context.Products.ToList();
            return products;
        }

        //GET: Get Products
        public Product GetProduct(int id)
        {
            var product = _context.Products.Include(c => c.Category).Where(c => c.Id == id).SingleOrDefault();
            return product;
        }

        //POST: New Product
        [HttpPost]
        public string PostProduct(Product product)
        {
            _context.Products.Add(product);
            
            if(_context.SaveChanges() > 0)
            {
                return "success";
            }
            else
            {
                return "Failed";
            }
            
        }

        //PUT: Edit Product
        [HttpPut]
        public string PutProduct(int id, Product product)
        {
            Product productInDb = _context.Products.Find(id);

            productInDb.Name = product.Name;
            productInDb.CategoryId = product.CategoryId;
            productInDb.Price = product.Price;
            productInDb.Quantity = product.Quantity;
            productInDb.Short_Desc = product.Short_Desc;
            productInDb.Long_Desc = product.Long_Desc;
            productInDb.SmallImagePath = product.SmallImagePath;
            productInDb.LargeImagePath = product.LargeImagePath;

            if (_context.SaveChanges() > 0)
            {
                return "updated";
            }
            else
            {
                return "Failed";
            }
        }

        //DELETE: Delete Product
        [HttpDelete]
        public string DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);

            _context.Products.Remove(product);

            if (_context.SaveChanges() > 0)
            {
                return "deleted";
            }
            else
            {
                return "Failed";
            }
        }

    }
}
