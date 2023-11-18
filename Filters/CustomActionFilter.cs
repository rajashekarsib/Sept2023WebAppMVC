using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sept2023WebAppMVC.Filters
{
    public class CustomActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Items["timer"] = Stopwatch.StartNew();

            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //logic
            Log("Action is executing...");
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var sw = (filterContext.HttpContext.Items["timer"] as Stopwatch).ElapsedMilliseconds;

            //logic
            Log("Action is executed");
            base.OnActionExecuted(filterContext);
        }

        private void Log(string message)
        {
            //store db or text file log message information
            Console.WriteLine(message);
        }
    }
}