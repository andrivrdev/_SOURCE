using BlazorApp2.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlazorApp2.Data;
using BlazorApp2.Areas.Identity.Data;

namespace BlazorApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("BlazorApp2ContextConnection") ?? throw new InvalidOperationException("Connection string 'BlazorApp2ContextConnection' not found.");

            builder.Services.AddDbContext<BlazorApp2Context>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<BlazorApp2User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<BlazorApp2Context>();

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
