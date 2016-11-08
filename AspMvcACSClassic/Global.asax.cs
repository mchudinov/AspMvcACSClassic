using System;
using System.Diagnostics;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;

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
            var principal = (ClaimsPrincipal)System.Web.HttpContext.Current.User;
            var bootstrapContext = (BootstrapContext)principal.Identities.First().BootstrapContext;            
            var claims = principal.Claims;
            var token = GetToken(bootstrapContext);
            var identity = principal.Identity;
            Debug.WriteLine("Session_Start. Identity name:" + identity.Name + " IsAuthenticated:" + identity.IsAuthenticated);
        }

        private static string GetToken(BootstrapContext bootstrapContext)
        {
            var builder = new StringBuilder();
            using (var writer = XmlWriter.Create(builder))
            {
                new Saml2SecurityTokenHandler(new SamlSecurityTokenRequirement()).WriteToken(writer, bootstrapContext.SecurityToken);
            }
            return builder.ToString();            
        }        
    }
}