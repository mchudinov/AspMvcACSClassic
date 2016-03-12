using System;
using System.IdentityModel.Services;
using System.Web.Mvc;

namespace AspMvcACSClassic.Controllers
{
    public class AccountController : Controller
    {
        public void SignIn()
        {
            if (!Request.IsAuthenticated)
            {
                FederatedAuthentication.WSFederationAuthenticationModule.SignIn(String.Empty);
            }
        }

        public void SignOut()
        {
            string callbackUrl = Url.Action("SignOutCallback", "Account", routeValues: null, protocol: Request.Url.Scheme);
            WSFederationAuthenticationModule.FederatedSignOut(new Uri(FederatedAuthentication.WSFederationAuthenticationModule.Issuer), new Uri(callbackUrl));
            FederatedAuthentication.WSFederationAuthenticationModule.SignOut(callbackUrl);
        }

        public ActionResult SignOutCallback()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Claims", "Home");
            }
            return View();
        }
    }
}