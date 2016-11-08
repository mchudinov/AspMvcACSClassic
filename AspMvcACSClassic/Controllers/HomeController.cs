using System.Web.Mvc;

namespace AspMvcACSClassic.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Claims() 
        { 
            ViewBag.Message = "Your claims page";
            ViewBag.ClaimsIdentity = System.Web.HttpContext.Current.User.Identity;
            return View();
        }
    }
}
