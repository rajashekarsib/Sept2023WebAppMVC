using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sept2023WebAppMVC.Areas.Admin.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: Admin/AdminPanel
        public ActionResult Index()
        {
            return View();
        }
    }
}