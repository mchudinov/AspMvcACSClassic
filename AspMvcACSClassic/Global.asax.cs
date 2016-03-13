using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspMvcACSClassic
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Debug.WriteLine("Application_Start");
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            var principal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var claims = ((ClaimsPrincipal)Thread.CurrentPrincipal).Claims;
            var identity = Thread.CurrentPrincipal.Identity;
            Debug.WriteLine("Session_Start. Identity name:" + identity.Name + " IsAuthenticated:" + identity.IsAuthenticated);
        }
    }
}