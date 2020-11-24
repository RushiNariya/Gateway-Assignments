using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SourceControlAssignment1.Models;
using SourceControlAssignment1.ViewModels;

namespace SourceControlAssignment1.Controllers
{

    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Create()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerMembershipViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerMembershipViewModel()
                {
                    MembershipTypes = _context.MembershipTypes.ToList(),
                    Customer = customer
                };
                return View("Create",viewModel);
            }
            string filename = Path.GetFileNameWithoutExtension(customer.Photo.FileName);
            string extension = Path.GetExtension(customer.Photo.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            customer.PhotoPath = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            customer.Photo.SaveAs(filename);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}