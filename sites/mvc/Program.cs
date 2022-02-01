var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    "default",
    "/{controller=Root}/{action=Index}/"
);

app.MapControllerRoute(
    "blog",
    "/{controller=Blog}/{action=New}/{id?}"
);

app.Run();
