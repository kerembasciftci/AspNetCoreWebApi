using Autofac.Extensions.DependencyInjection;
using Autofac;
using Udemy.Web.Modules;
using Udemy.Repository;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Udemy.Service.Mapping;
using System.Reflection;
using FluentValidation.AspNetCore;
using Udemy.Service.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());


builder.Services.AddDbContext<AppDbContext>(
   x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
   {
       option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
   }
    ));

builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));


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
