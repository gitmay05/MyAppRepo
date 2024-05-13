using AllinOneApiApplication.Interface;
using AllinOneApiApplication.Interface.ApplicationUser;
using AllinOneApiApplication.Interface.Form;
using AllinOneApiApplication.Repository;
using AllinOneApiApplication.Repository.Form;
using AllinOneApiApplication.Repository.User;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddScoped<IForm, FormRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IApplicationUser, UserReposistory>();
builder.Services.AddSingleton<IForm, FormRepository>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
