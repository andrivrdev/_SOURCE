using BlazorSecurePoll.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlazorSecurePoll.Data;
using BlazorSecurePoll.Areas.Identity.Data;

namespace BlazorSecurePoll
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("BlazorSecurePollDBContextConnection") ?? throw new InvalidOperationException("Connection string 'BlazorSecurePollDBContextConnection' not found.");

            builder.Services.AddDbContext<BlazorSecurePollDBContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<BlazorSecurePollUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<BlazorSecurePollDBContext>();

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
