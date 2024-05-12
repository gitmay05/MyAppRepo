using AllinOneApiApplication.Controllers;
using AllinOneApiApplication.Interface.ApplicationUser;
using AllinOneApiApplication.Interface.Form;
using AllinOneApiApplication.Model.UserModel;
using AllinOneApiApplication.Repository.Form;
using AllinOneApiApplication.Repository.User;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddControllers();
builder.Services.AddMediatR(a => a.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddSingleton<IApplicationUser,UserReposistory>();
builder.Services.AddSingleton<IForm, FormRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
