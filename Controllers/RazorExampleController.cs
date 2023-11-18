using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sept2023WebAppMVC.Controllers
{
    public class RazorExampleController : Controller
    {
        // GET: RazorExample
        public ActionResult Index()
        {
            return View();
        }
    }
}