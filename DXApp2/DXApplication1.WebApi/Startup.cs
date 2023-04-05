using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Xpo;
using Microsoft.OpenApi.Models;
using DevExpress.ExpressApp.WebApi.Services;
using Microsoft.AspNetCore.OData;
using DevExpress.ExpressApp.Core;
using DXApplication1.WebApi.Core;
using DevExpress.ExpressApp.AspNetCore.WebApi;

namespace DXApplication1.WebApi;

public class Startup {
    public Startup(IConfiguration configuration) {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services) {
        services
            .AddSingleton<IXpoDataStoreProvider>((serviceProvider) => {
                string connectionString = null;
                if(Configuration.GetConnectionString("ConnectionString") != null) {
                    connectionString = Configuration.GetConnectionString("ConnectionString");
                }
#if EASYTEST
                if(Configuration.GetConnectionString("EasyTestConnectionString") != null) {
                    connectionString = Configuration.GetConnectionString("EasyTestConnectionString");
                }
#endif
                return XPObjectSpaceProvider.GetDataStoreProvider(connectionString, null, true);
            })
            .AddScoped<IObjectSpaceProviderFactory, ObjectSpaceProviderFactory>()
            .AddSingleton<IWebApiApplicationSetup, WebApiApplicationSetup>();



        services.AddAuditTrailXpoServices();
        services.AddXafReportingCore(options => {
            options.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.ReportDataV2);
        });
        services
            .AddXafWebApi(Configuration, options => {
                // Make your business objects available in the Web API and generate the GET, POST, PUT, and DELETE HTTP methods for it.
                // options.BusinessObject<YourBusinessObject>();
            })
            .AddXpoServices();
        services
            .AddControllers()
            .AddOData((options, serviceProvider) => {
                options
                    .AddRouteComponents("api/odata", new EdmModelBuilder(serviceProvider).GetEdmModel())
                    .EnableQueryFeatures(100);
            });

        services.AddSwaggerGen(c => {
            c.EnableAnnotations();
            c.SwaggerDoc("v1", new OpenApiInfo {
                Title = "DXApplication1 API",
                Version = "v1",
                Description = @"Use AddXafWebApi(options) in the DXApplication1.WebApi\Startup.cs file to make Business Objects available in the Web API."
            });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        if(env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DXApplication1 WebApi v1");
            });
        }
        else {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. To change this for production scenarios, see: https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseRequestLocalization();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
        });
    }
}
