using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sept2023WebAppMVC.Areas.Student.Controllers
{
    public class StudentViewController : Controller
    {
        // GET: Student/StudentView
        public ActionResult Index()
        {
            return View();
        }
    }
}