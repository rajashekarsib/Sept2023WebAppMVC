using Sept2023WebAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sept2023WebAppMVC.Controllers
{
    public class ValidationExampleController : Controller
    {
        // GET: ValidationExample
        public ActionResult Validations()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Validations(UserModel userModel )
        {

            if (ModelState.IsValid) { 
            // save statements
            }

            return View(userModel);
        }
    }
}