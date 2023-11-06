
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PDWebt1.Areas.Identity.Data;
using PDWebt1.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PDWebt1ContextConnection") ?? throw new InvalidOperationException("Connection string 'PDWebt1ContextConnection' not found.");

builder.Services.AddDbContext<PDWebt1Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<PDWebt1User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<PDWebt1Context>();

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
