var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.MapControllerRoute(
    "root",
    "{action=Index}/",
    new {controller = "Root"}
);

app.MapControllerRoute(
    "blogIndex",
    "{controller=Home}/{action}/",
    new{action = "Index"}
);

app.MapControllerRoute(
    "blogSingle",
    "{controller=Blog}/{id?}/",
    new {action = "Index"}
);

app.Run();