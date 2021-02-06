using System;
using Frank.Libraries.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Frank.Apps.DependencyInjectionWpf
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddScoped<App>();
                    services.AddScoped<MainWindow>();
                    services.AddScoped<ILayoutConstructorService, LayoutConstructorService>();

                    services.AddLogging(builder => builder.AddProvider(new FileLoggerProvider(new FileLoggerConfiguration { LogLevel = LogLevel.Information })));

                    services.AddHostedService<WindowHost>(); // Must be added last
                });

            host.Build().Run();
        }
    }
}
