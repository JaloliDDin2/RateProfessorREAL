using Microsoft.AspNetCore.Mvc;

namespace MyRateApp2.Controllers
{
    public class AppRolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
