using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCViewDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public string Mycontroller()
        {
            return "Hi, I am a controller";
        }

        public ActionResult MyView()
        {
            return View();
        }
    }
}