using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Frank.Apps.StarMap
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<App>();
                    services.AddScoped<MainWindow>();

                    services.AddHostedService<WindowHost>(); // Must be added last
                });

            host.Build().Run();
        }
    }
}
