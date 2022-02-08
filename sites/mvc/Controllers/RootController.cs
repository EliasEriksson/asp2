using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers
{
    public class RootController : Controller
    {
        /**
         * redirects from / to rootURL
         *
         * will mostly be used on local development as the webserver wont serve
         * the application this url.
         * makes it easy to navigate to rootURL by just clicking the link in the terminal.
         */
        [HttpGet("/")]
        public IActionResult Root()
        {
            return this.RedirectToAction("Index", "Root");
        }
        
        /**
         * serves the home view when the user goes to rootURL/
         */
        public IActionResult Index()
        {
            ViewData["title"] = "Home";
            return this.View();
        }

        /**
         * serves the about view when the user goes to rootURL/About
         */
        public IActionResult About()
        {
            ViewData["title"] = "About";
            return this.View();
        }
    }
}