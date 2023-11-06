using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Areas.Identity.Data;
using WebApplication2.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebApplication2ContextConnection") ?? throw new InvalidOperationException("Connection string 'WebApplication2ContextConnection' not found.");

builder.Services.AddDbContext<WebApplication2Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<WebApplication2User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WebApplication2Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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

app.MapRazorPages();

app.Run();
