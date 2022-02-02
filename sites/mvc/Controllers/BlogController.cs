using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using Newtonsoft.Json;

namespace mvc.Controllers
{
    public class BlogController : Controller
    {
        private static readonly string PostFile = Path.Combine(Environment.CurrentDirectory, "posts.json");

        private static void Save(List<BlogModel> models)
        {
            System.IO.File.WriteAllText(PostFile, JsonConvert.SerializeObject(models, Formatting.Indented));
        }

        private static List<BlogModel> Load()
        {
            Console.WriteLine(PostFile);
            if (!System.IO.File.Exists(PostFile))
            {
                Save(new List<BlogModel>());
            }

            return JsonConvert.DeserializeObject<List<BlogModel>>(System.IO.File.ReadAllText(PostFile)) ??
                   new List<BlogModel>();
        }

        private static BlogModel? GetPostFromId(string id, List<BlogModel> posts)
        {
            foreach (var post in posts)
            {
                if (post.Id == id)
                {
                    return post;
                }
            }

            return null;
        }

        public IActionResult Index(string? id)
        {
            ViewData["title"] = "Feed";
            var posts = Load();
            if (id == null) return this.View("Index", posts);
            
            var post = GetPostFromId(id, posts);

            if (post != null)
            {
                ViewData["title"] = $"Post by {post.User}";
                return this.View("Single", post);
            }
            
            return this.RedirectToAction("Index");

        }

        public IActionResult New()
        {
            ViewData["title"] = "New Post";
            ViewBag.previousName = HttpContext.Session.GetString("previousName") ?? "";
            return this.View("New");
        }

        [HttpPost]
        public IActionResult New(BlogModel model)
        {
            ViewData["title"] = "New Post";
            this.ModelState.Clear();
            model.Id = Guid.NewGuid().ToString();
            model.Time = DateTime.Now;
            if (!this.TryValidateModel(model))
            {
                return this.View("New", model);
            }

            var posts = Load();
            posts.Add(model);
            Save(posts);
            // model.User null warning suppressed since the model have
            // validated here and therefor can not be null
            HttpContext.Session.SetString("previousName", model.User!);
            return this.RedirectToAction(controllerName:"Blog", actionName: "Index", routeValues: model.Id);

        }
    }
}