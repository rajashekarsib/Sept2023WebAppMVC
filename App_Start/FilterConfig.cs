using Sept2023WebAppMVC.Filters;
using System.Web;
using System.Web.Mvc;

namespace Sept2023WebAppMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new CustomActionFilter());
            //filters.Add(new CustomAuthenticationFilter());
            filters.Add(new CustomErrorHandlingExample());
            filters.Add(new CustomResultFilter());
        }
    }
}
