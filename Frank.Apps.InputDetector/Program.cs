using System;
using Frank.Apps.InputDetector;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();
                //services.AddScoped<App>();
                //services.AddScoped<MainWindow>();

                //services.AddHostedService<WindowHost>(); // Must be added last
            }).Build().Run();
