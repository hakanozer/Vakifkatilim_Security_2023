using Microsoft.AspNetCore.Mvc;

namespace OneDay.Controllers
{
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            //string control = HttpContext.Session.GetString("user");
            //if (control != null) { }
            return View();
        }
    }
}
