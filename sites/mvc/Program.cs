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
app.UsePathBase(rootUrl);
app.UseStaticFiles(rootUrl);


app.MapControllerRoute(
    "root",
    $"{rootUrl}/{{action=Index}}/",
    new {controller = "Root"}
);

app.MapControllerRoute(
    "blogIndex",
    $"{rootUrl}/{{controller=Home}}/{{action}}/",
    new{action = "Index"}
);

app.MapControllerRoute(
    "blogSingle",
    $"{rootUrl}/{{controller=Blog}}/{{id?}}/",
    new {action = "Index"}
);

app.Run();