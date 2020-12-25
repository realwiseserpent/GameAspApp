using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Security.Authentication;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace GameAspApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddDebug();
                logging.AddNLog();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureKestrel(serverOptions =>
                {
                    serverOptions.Limits.MinRequestBodyDataRate = new MinDataRate(100, TimeSpan.FromSeconds(10));
                    serverOptions.Limits.MinResponseDataRate = new MinDataRate(100, TimeSpan.FromSeconds(10));
                    serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2);
                    serverOptions.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(1);
                    // configure SSL protocol for example
                    serverOptions.ConfigureHttpsDefaults(listenOptions =>
                    {
                        listenOptions.SslProtocols = SslProtocols.Tls12;
                    });
                })
                .UseStartup<Startup>();
            });
    }
}
