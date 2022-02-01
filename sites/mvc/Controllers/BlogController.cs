using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index(string? id)
        {
            if (id == null)
            {
                return this.View("Index");
            }
            return this.View("Single");
        }

        public IActionResult New()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult New(BlogModel model)
        {
            this.ModelState.Clear();
            model.Id = Guid.NewGuid().ToString();
            model.Time = DateTime.Now;
            if (this.TryValidateModel(model))
            {
                return this.RedirectToAction(controllerName: "Blog", actionName: "Index");
            }

            return this.View("New", model);
        }

        public IActionResult Delete()
        {
            return this.View();
        }
    }
}