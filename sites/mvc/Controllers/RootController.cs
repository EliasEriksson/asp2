using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers
{
    public class RootController : Controller
    {
        [HttpGet("/")]
        public IActionResult Root()
        {
            return this.RedirectToAction("Index", "Root");
        }
        
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