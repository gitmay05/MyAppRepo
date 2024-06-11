using AllinOneApiApplication.Interface;
using AllinOneApiApplication.Interface.ApplicationUser;
using AllinOneApiApplication.Interface.Form;
using AllinOneApiApplication.Interface.Login;
using AllinOneApiApplication.Interface.Role;
using AllinOneApiApplication.Repository;
using AllinOneApiApplication.Repository.Form;
using AllinOneApiApplication.Repository.Login;
using AllinOneApiApplication.Repository.Role;
using AllinOneApiApplication.Repository.User;
using AllinOneWebApplication.Filter;
using AllinOneWebApplication.MiddleWare;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddScoped<IForm, FormRepository>();

// Add services to the container.
// Add MVC and configure action filters
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<CustomActionFilter>(); // Add the LoggingActionFilter to MVC
    options.Filters.Add<GlobalExceptionFilter>(); // Add the GlobalExceptionFilter to MVC

});

builder.Services.AddSingleton<IApplicationUser, UserReposistory>();
builder.Services.AddSingleton<IForm, FormRepository>();
builder.Services.AddSingleton<IRole, RoleRepository>();
builder.Services.AddSingleton<ILogin, LoginReposistory>();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(60);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
// Use custom authentication middleware before routing middleware
app.UseAuthenticationMiddleware();



app.MapControllerRoute(
    name: "default",
     //pattern: "{controller=Home}/{action=Index}/{id?}");
     pattern: "{controller=login}/{action=login}/{id?}");

app.Run();
