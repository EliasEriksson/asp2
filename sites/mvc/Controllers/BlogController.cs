using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using Newtonsoft.Json;

namespace mvc.Controllers
{
    public class BlogController : Controller
    {
        /**
         * path to the json file
         */
        private static readonly string PostFile = Path.Combine(Environment.CurrentDirectory, "posts.json");

        /**
         * saves a list of blog models to the json file
         */
        private static void Save(List<BlogModel> models)
        {
            System.IO.File.WriteAllText(PostFile, JsonConvert.SerializeObject(models, Formatting.Indented));
        }
        /**
         * loads a list of blog models from the json file
         */
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
        
        /**
         * finds and returns a blog post with specified id
         */
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

        /**
         * the blog index
         *
         * serves different views depending on if id is specified or not.
         * if id is specified the single view is served.
         * if id is not specified the index view is served.
         * if an id does not exist in the json file the user is
         * redirected to the this URL but without ID and will be served the index view.
         */
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
        /**
         * serves the new post form view.
         */
        public IActionResult New()
        {
            ViewData["title"] = "New Post";
            ViewBag.previousName = HttpContext.Session.GetString("previousName") ?? "";
            return this.View("New");
        }

        /**
         * handles data from posted blog form
         *
         * if data validates the post is added and user is redirected to be served the
         * view for the specific blog post.
         * if the data does not validate the user is served the form view again.
         */
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
            //          clearly the action name, good job asp!  vvvvvvvvvvvvvvvvvvvvvvv
            return this.RedirectToAction(controllerName:"Blog", actionName: $"{model.Id}");

        }
    }
}