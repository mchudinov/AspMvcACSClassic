using System;
using System.Security.Claims;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;

namespace AspMvcACSClassic
{
    public class MvcApplication : System.Web.HttpApplication
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(MvcApplication));

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            _log.Info("Application_Start");
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            var principal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var claims = ((ClaimsPrincipal)Thread.CurrentPrincipal).Claims;
            var identity = Thread.CurrentPrincipal.Identity;
            _log.Info("Session_Start. Identity name:" + identity.Name + " IsAuthenticated:" + identity.IsAuthenticated);
        }
    }
}