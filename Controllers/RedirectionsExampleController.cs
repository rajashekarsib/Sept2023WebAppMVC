using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sept2023WebAppMVC.Controllers
{
    public class RedirectionsExampleController : Controller
    {
        // GET: RedirectionsExample
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            // Response.Redirect("/PersonDetails/GetPersonDetails");           
            // return View();
            /// return RedirectToAction("Index"); //Same controller

            //return View("Index");
            return RedirectToAction("GetPersonDetails", "PersonDetails");

        }
    }
}