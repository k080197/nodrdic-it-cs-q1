using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace First
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup2>();

        public class Startup2
        {
            public void Configure(IApplicationBuilder builder, IHostingEnvironment environment)
            {
                if (environment.IsDevelopment())
                {
                    builder.UseDeveloperExceptionPage();
                }

                builder.Use(PostUsersRequest);
                builder.Use(GetBooksRequest);
                builder.Use(GetFailedRequest);
                builder.Run(GetAllRequest);
            }

            private static Task PostUsersRequest(HttpContext context, Func<Task> next)
            {
                if (context.Request.Method.ToUpper() == "POST" &&
                context.Request.Path.StartsWithSegments("/user"))
                {
                    context.Response.StatusCode = 201;
                    return context.Response.WriteAsync("Users page");
                }

                return next();
            }
            private static Task GetBooksRequest(HttpContext context, Func<Task> next)
            {
                if (context.Request.Method.ToUpper() == "GET" &&
                context.Request.Path.StartsWithSegments("/book"))
                {
                    context.Response.StatusCode = 200;
                    return context.Response.WriteAsync("Books page");
                }

                return next();
            }

            private static Task GetFailedRequest(HttpContext context, Func<Task> next)
            {
                if (context.Request.Method.ToUpper() == "GET" &&
                    context.Request.Path.StartsWithSegments("/exception"))
                {
                    throw new InvalidOperationException();
                }

                return next();
            }

            private static Task GetAllRequest(HttpContext context)
            {
                context.Response.StatusCode = 200;
                return context.Response.WriteAsync("Generic page.");
            }
        }
    }
}
