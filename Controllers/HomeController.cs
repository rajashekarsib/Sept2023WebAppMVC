using Sept2023WebAppMVC.Filters;
using Sept2023WebAppMVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sept2023WebAppMVC.Controllers
{
    [CustomErrorHandlingExample]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ErrorView()
        {
            //Loger.Log("skilliceberg");

            //try
            //{
                string name = "xyz";
                int num = Convert.ToInt32(name);
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
            return View();
        }
    }
}