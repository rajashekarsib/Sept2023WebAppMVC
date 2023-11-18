using Sept2023WebAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sept2023WebAppMVC.Controllers
{
    public class ViewBagViewDataTempDataController : Controller
    {
        // GET: ViewBagViewDataTempData
        public ActionResult ViewBagExample()
        {
            ViewBag.message = "Wel Come to ViewBag message";
            return View();
        }


        public ActionResult ViewDataExample()
        {
            ViewData["Name"] = "Rajashekar";

            //CredentialModel credentialModel = new CredentialModel();
            //credentialModel.Username = "sita";
            //credentialModel.Password = "Sita1234";          
            //ViewData["KeyCredentials"] = credentialModel;

            ViewData["KeyCredentials"] = new CredentialModel { 
                                                                 Username = "sita",
                                                                 Password="Sita1234"
                                                              };

            return View();
        }


        public ActionResult TempDataExample1()
        {
            TempData["DateTimeNow"] = DateTime.Now;
            return View();
        }

        public ActionResult TempDataExample2()
        {
           if( TempData.ContainsKey("DateTimeNow"))
            {
                ViewBag.temp = TempData["DateTimeNow"];                
            }
            return View();
        }
    }
}