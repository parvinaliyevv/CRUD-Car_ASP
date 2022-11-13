var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "Home",
    defaults: new { controller = "Car", action = "Home" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "Create",
    defaults: new { controller = "Car", action = "Create" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "Read",
    defaults: new { controller = "Car", action = "Read" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "Update",
    defaults: new { controller = "Car", action = "Update" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "Delete",
    defaults: new { controller = "Car", action = "Delete" }
);

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Car}/{action=Home}/{id?}"
);

app.Run();
