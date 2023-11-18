using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sept2023WebAppMVC.Controllers
{
    [OverrideAuthentication]
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin123")
            {
                HttpContext.Session["admin"] = "Rajashekar";
                return RedirectToAction("UserDeatilsList", "UserDetails");
            }
            else if (username == "admin1" && password == "admin123")
            {
                HttpContext.Session["admin"] = "Srikanth";
                return RedirectToAction("UserDeatilsList", "UserDetails");
            }
            else
            {
                return View();
            }
        }
    }
}