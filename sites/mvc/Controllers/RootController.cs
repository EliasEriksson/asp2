using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers
{
    public class RootController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}