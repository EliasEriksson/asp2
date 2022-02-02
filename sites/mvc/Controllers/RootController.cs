using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers
{
    public class RootController : Controller
    {
        public IActionResult Index()
        {
            ViewData["title"] = "Home";
            return this.View();
        }

        public IActionResult About()
        {
            ViewData["title"] = "About";
            return this.View();
        }
    }
}