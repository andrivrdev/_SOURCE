using Microsoft.AspNetCore.Hosting;

namespace PDAPI
{
    public class Program
    {
        public static void ExternalNetwork(string[] args)
        {
            // use this to allow command line parameters in the config
            var configuration = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();


            var hostUrl = configuration["hosturl"];
            if (string.IsNullOrEmpty(hostUrl))
                hostUrl = "http://0.0.0.0:9090";


            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls(hostUrl)
                .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
                .UseStartup<Startup>()
                .UseConfiguration(configuration)
                .Build();

            host.Run();
        }

        public static void Main(string[] args)
        {
            var xConnected = PDAPI.clsSSClient.zSSClient.ConnectAsync("andrivr@gmail.com", "passNEWm.3");
            xConnected.Wait();

            int aaaa = 1;

            //ExternalNetwork(args);
            CreateHostBuilder(args).Build().Run();

            /*
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.Run();*/
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}