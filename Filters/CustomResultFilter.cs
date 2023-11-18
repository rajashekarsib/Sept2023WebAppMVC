using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using Sept2023WebAppMVC.Utilities;

namespace Sept2023WebAppMVC.Filters
{
    public class CustomResultFilter : IResultFilter
    {

        //Stopwatch stopwatch;
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //stopwatch = new Stopwatch();
            //stopwatch.Start();
            filterContext.HttpContext.Items["timer"] = Stopwatch.StartNew();
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //stopwatch.Stop();
             var timer= filterContext.HttpContext.Items["timer"] as Stopwatch;
            Loger.LogerMessage(filterContext.RouteData.Values["controller"].ToString(),filterContext.RouteData.Values["action"].ToString(),timer.ElapsedMilliseconds);
            
        }
    }
}