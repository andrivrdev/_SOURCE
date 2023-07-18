using Microsoft.AspNetCore.Hosting;

namespace Try1
{
	public class Program
	{
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<clsStartup>();
				});


		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();

			/*
			var builder = WebApplication.CreateBuilder(args);
			var app = builder.Build();

			app.MapGet("/", () => "Hello World!");

			app.Run();
			*/
		}
	}
}