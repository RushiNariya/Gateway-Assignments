using Microsoft.AspNet.Identity;
using SourceControlFinalAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SourceControlFinalAssignment.ExceptionHandling;
using log4net;

namespace SourceControlFinalAssignment.Controllers
{
    [UserExceptionHandler]
    public class HomeController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));
        public ActionResult Index()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            string email = User.Identity.GetUserName();
            if (string.IsNullOrEmpty(email))
            {
                Log.Debug("Redirect to login from user details page.");
                return RedirectToAction("Login", "Account");
            }
            var applicationUser = dbContext.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
            ViewBag.User = applicationUser;
            Log.Info("User details for username: " + applicationUser.Email);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            Log.Debug("About action from Home controller is called.");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            Log.Debug("Contact action from Home controller is called.");
            return View();
        }
    }
}