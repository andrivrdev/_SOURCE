﻿using Microsoft.AspNetCore.Hosting;

namespace PDRestAPI
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
            ExternalNetwork(args);
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}