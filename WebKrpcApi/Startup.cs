using Krpc.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebKrpcApi.Infra.CrossCutting.DependecyContainer;

namespace WebKrpcApi
{
    public class Startup
    {
        private IConfiguration Configuration {get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiConfigurations(Configuration);

            services.AddControllers();
            services.AddSwaggerGen(opcions =>
            {
                opcions.SwaggerDoc(
                    "WebKrpcApi",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                    Title = "Web Krpc",
                    Version = "1.0"
                    });
            }
            );
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("swagger/WebKrpcApi/swagger.json", "WebKrpcApi");
                options.RoutePrefix = "";
            });
        }
    }
}
