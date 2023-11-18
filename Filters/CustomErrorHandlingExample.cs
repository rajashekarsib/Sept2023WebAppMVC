using Sept2023WebAppMVC.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sept2023WebAppMVC.Filters
{
    public class CustomErrorHandlingExample : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Exception exception = filterContext.Exception;
            string controllerName= filterContext.RouteData.Values["controller"].ToString();
            string actionMethodName = filterContext.RouteData.Values["action"].ToString();
            Loger.LogerMessage(controllerName, actionMethodName, exception.Message);
            filterContext.Result = new ViewResult
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(exception.Message)
            };
            filterContext.ExceptionHandled = true;
        }
    }
}