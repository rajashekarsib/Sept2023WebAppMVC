using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Sept2023WebAppMVC.Filters
{
    public class CustomAuthenticationFilter:IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext authenticationContext)
        {
            bool isAuthenticate = authenticationContext.HttpContext.Session["admin"].ToString() == "Rajashekar";
            if (!isAuthenticate)
            {
                authenticationContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext authenticationChallengeContext)
        {
            if(authenticationChallengeContext.Result==null || authenticationChallengeContext.Result is HttpUnauthorizedResult)
            {
                authenticationChallengeContext.Result = new RedirectResult("~/Authentication/Login");
            }
        }
    }
}