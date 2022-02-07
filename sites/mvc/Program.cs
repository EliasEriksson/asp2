var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();
const string rootUrl = "/aspdotnet/moment2";

app.UseSession();
app.UseRouting();
app.UseStaticFiles(rootUrl);


app.MapControllerRoute(
    "root",
    $"{rootUrl}/{{action=Index}}/",
    new {controller = "Root"}
);

// how does asp know to use the blog controller?
// that is asps inner secret
app.MapControllerRoute(
    "blogIndex",
    $"{rootUrl}/{{controller}}/{{action}}/",
    new {action = "Index"}
);

app.MapControllerRoute(
    "blogSingle",
    $"{rootUrl}/{{controller}}/{{id?}}/",
    new {action = "Index", controller="Blog"}
);

app.Run();
