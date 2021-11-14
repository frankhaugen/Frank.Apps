using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Frank.Apps.SecurityCam;

public class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                //services.AddHostedService<Worker>();
                services.AddScoped<App>();
                services.AddScoped<MainWindow>();

                services.AddHostedService<WindowHost>(); // Must be added last
            });
}