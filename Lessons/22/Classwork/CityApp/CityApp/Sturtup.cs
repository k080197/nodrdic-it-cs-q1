using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace CityApp
{
    public class Sturtup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(
            IApplicationBuilder builder, 
            IHostingEnvironment envorinment)
        {
            if (envorinment.EnvironmentName  == "local")
            {
                builder.UseDeveloperExceptionPage();
            }

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
