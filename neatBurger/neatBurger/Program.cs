using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using neatBurger.Models.entities;
using neatBurger.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();

builder.Services.AddDbContext<NeatContext>(x =>
{
    x.UseMySql("server=localhost;user=root;password=root;database=neat", 
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));
});//sirve para inyectar el contexto

builder.Services.AddTransient<MenuRepository>();
builder.Services.AddTransient<ClasificacionRepository>();
var app = builder.Build();



app.MapDefaultControllerRoute();
app.UseStaticFiles();

app.Run();
