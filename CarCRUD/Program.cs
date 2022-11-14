var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{action}",
    defaults: new { controller = "Car" }
);

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Car}/{action=Home}/{id?}"
);

app.Run();
