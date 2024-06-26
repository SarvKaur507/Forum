using AutoMapper;
using Forum.Directories;
using Forum.Directories.IDirectiories;
using Forum.Models;
using Forum.Models.Mappers;
using Forum.Services;
using Forum.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ForumContext>(options => options.UseMySql(builder.Configuration.
    GetConnectionString("defaultconnection"),
 ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("defaultconnection")),
  mysqlOptions =>
  {
      mysqlOptions.EnableRetryOnFailure();
      mysqlOptions.CommandTimeout(900);
  }));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IHomeDirectory, HomeDirectory>();
var mapperconfig = new MapperConfiguration(
    cfg => cfg.AddProfile(new PostMapper())
    );
builder.Services.AddSingleton(mapperconfig.CreateMapper());
builder.Services.AddTransient<IHome, Home>();
builder.Services.AddTransient<IAuthDirectory, AuthDirectory>();
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
    pattern: "{controller=Auth}/{action=Register}/{id?}");

app.Run();
