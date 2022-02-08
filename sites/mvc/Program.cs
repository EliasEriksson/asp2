var builder = WebApplication.CreateBuilder(args);
// activates MVC
builder.Services.AddControllersWithViews();

// required to use sessions
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

// location on live host
const string rootUrl = "/aspdotnet/moment2";

// activate sessions
app.UseSession();
// activate routing
app.UseRouting();
// activate static files and tells dotnet to serve them from the rootURL instead of /
app.UseStaticFiles(rootUrl);

// maps root controller to rootURL/
app.MapControllerRoute(
    "root",
    $"{rootUrl}/{{action}}/",
    new {controller = "Root", action="Index"}
);

// maps the blog controller to rootURL/Blog/
// how does asp know to use the blog controller?
// that is asps inner secret
app.MapControllerRoute(
    "blogIndex",
    $"{rootUrl}/{{controller}}/{{action}}/",
    new {action = "Index"}
);

// maps specific blog posts to rootURL/Blog/id
app.MapControllerRoute(
    "blogSingle",
    $"{rootUrl}/{{controller}}/{{id?}}/",
    new {action = "Index", controller="Blog"}
);

app.Run();
