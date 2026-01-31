using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.FullName = "Chao mung ban den voi ASP.NET Core MVC";
            return View();
        }
    }
}