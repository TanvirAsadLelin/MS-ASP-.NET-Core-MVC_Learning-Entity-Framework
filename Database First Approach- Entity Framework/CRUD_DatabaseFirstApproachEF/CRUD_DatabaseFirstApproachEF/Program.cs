using CRUD_DatabaseFirstApproachEF.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connection = @"Server=DESKTOP-51RF4TH\SQLEXPRESS;Database=CRUD_DatabaseFirstApproach_DB;User Id=sa;Password=1996;";

builder.Services.AddDbContext<CRUD_DatabaseFirstApproach_DBContext>(options => options.UseSqlServer(connection));
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
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.Run();
