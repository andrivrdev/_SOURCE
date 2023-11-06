using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DevExtremeAspNetCoreApp1.Data;
using DevExtremeAspNetCoreApp1.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DevExtremeAspNetCoreApp1ContextConnection") ?? throw new InvalidOperationException("Connection string 'DevExtremeAspNetCoreApp1ContextConnection' not found.");

builder.Services.AddDbContext<DevExtremeAspNetCoreApp1Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<DevExtremeAspNetCoreApp1User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DevExtremeAspNetCoreApp1Context>();

// Add services to the container.
builder.Services
    .AddRazorPages()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
