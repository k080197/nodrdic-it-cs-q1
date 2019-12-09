using System;
using Microsoft;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace CityApp
{
    public partial class Program
    {
        private static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            try
            {
                //logger.Debug("init main");
                BuilWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                LogManager.Shutdown();
            }
        }

        private static IWebHostBuilder BuilWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder()
                .ConfigureLogging(builder => builder.ClearProviders())
                .UseStartup<Sturtup>()
                .UseNLog();
        }
    }
}
