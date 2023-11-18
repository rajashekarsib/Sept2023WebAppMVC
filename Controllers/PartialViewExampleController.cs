using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sept2023WebAppMVC.Controllers
{
    public class PartialViewExampleController : Controller
    {
        // GET: PartialViewExample
        public ActionResult PartialView1()
        {
            return PartialView();  
        }

        public ActionResult PartialView2()
        {
            ViewBag.Fruits= new List<string> {"Apple","Banana","Mango" };
            return PartialView();
        }
        
        public ActionResult GetPartialView()
        {
            ViewBag.Fruits = new List<string> { "Apple", "Banana", "Mango","Orange","Pine Apple" };
            return View();
        }


        public ActionResult Index()
        {
            return PartialView("UserPartialView");
        }


        public ActionResult UsePatialViewWithLayOutPage()
        {
            return View();
        }


        public ActionResult UsePartialViewWithOutLayOutPage()
        {
            return View();
        }
    }
}