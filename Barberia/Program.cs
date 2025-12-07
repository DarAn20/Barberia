using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Barberia.Data;
using Microsoft.AspNetCore.Identity;
using Barberia.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BarberiaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BarberiaContext") ?? throw new InvalidOperationException("Connection string 'BarberiaContext' not found.")));

builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<BarberiaContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.MapRazorPages(); 

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
