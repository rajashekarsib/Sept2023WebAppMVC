using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Sept2023WebAppMVC.Controllers
{
    public class ActionResultReturnTypesController : Controller
    {
        // GET: ActionResultReturnTypes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JsonDataExample()
        {
            var data = new { StudentName = "Ram", Age = 30, Mobile = 98765432322 }; //Anonymous Data Type
            return Json(data,JsonRequestBehavior.AllowGet);
        }


        public ActionResult ContentDataExample()
        {
           // var data = new { StudentName = "Ram", Age = 30, Mobile = 98765432322 };
            //var json = new JavaScriptSerializer().Serialize(data); //  Serialization
             // return Content(json, "text/json"); // json data

             //   return Content("<h1> Skilliceberg </h1>", "text/html"); // html data

            return Content("<root> Skilliceberg </root>", "text/xml"); // xml data

            // return Content("this is from Content Acton Method","text/plan");    // text data         
        }


        
        public ActionResult JavaScriptDataExample()
        {
            var msg = "alert('It is from Java Script Return ActionResult');";
            return new JavaScriptResult() { Script = msg };
        }

        public ActionResult RedirectToAcitonExample()
        {
            return RedirectToRoute(new { controller = "Home", action = "About" });
        }

        public ActionResult FileExample()
        {
            byte[] data = new byte[10];
            return File(data, "image/jpeg"); // go to Image Controller see the example
        }

        public ActionResult RedirectToActionPermanentExample()
        {
            return RedirectToActionPermanent("Home", "Index");
        }

    }
}