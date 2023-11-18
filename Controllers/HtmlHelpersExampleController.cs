using Sept2023WebAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sept2023WebAppMVC.Controllers
{
    public class HtmlHelpersExampleController : Controller
    {
        // GET: HtmlHelpersExample
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username,string password)
        {
            ViewBag.usernamePassword = username + " " + password;
            return View();
        }


        public ActionResult PostCredentials()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostCredentials(CredentialModel credential)
        {
            return View(credential);
        }

        public ActionResult HtmlHelpers()
        {
            return View();
        }
    }
}