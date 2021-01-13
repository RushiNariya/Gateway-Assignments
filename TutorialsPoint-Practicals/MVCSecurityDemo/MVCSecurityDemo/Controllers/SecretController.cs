using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSecurityDemo.Controllers
{
    [Authorize(Users = "rushipatel@gmail.com")]
    public class SecretController : Controller
    {
        // GET: Secret
        
        public ContentResult Secret()
        {
            return Content("Secret informations here");
        }

        [AllowAnonymous]
        public ContentResult PublicInfo()
        {
            return Content("Public informations here");
        }
    }
}