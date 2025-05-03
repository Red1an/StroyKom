using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
