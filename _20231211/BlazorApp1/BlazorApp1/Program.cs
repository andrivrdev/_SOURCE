using BlazorApp1.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Data;

namespace BlazorApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("BlazorApp1ContextConnection") ?? throw new InvalidOperationException("Connection string 'BlazorApp1ContextConnection' not found.");

            builder.Services.AddDbContext<BlazorApp1Context>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<BlazorApp1User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<BlazorApp1Context>();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
