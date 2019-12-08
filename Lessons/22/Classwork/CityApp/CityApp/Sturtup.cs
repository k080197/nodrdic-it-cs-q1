using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CityApp
{
    public class Sturtup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwaggerGen(options => options.SwaggerDoc("v1", new Info { Title = "Cities", Version = "2.0" }));
        }

        public void Configure(
            IApplicationBuilder builder, 
            IHostingEnvironment envorinment)
        {
            if (envorinment.EnvironmentName  == "local")
            {
                builder.UseDeveloperExceptionPage();
            }

            builder.UseSwagger();
            builder.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cities API V1");
                }
            );
            builder.UseMvc(ConfigureRoutes);
        }

        private static void ConfigureRoutes(IRouteBuilder builder)
        {
            builder.MapRoute(name: "DefaultControllerAction", template: "{controller}/{action}/", defaults: new
            {
                Controller = "city",
                Action = "list"
            });
        }
    }
}
