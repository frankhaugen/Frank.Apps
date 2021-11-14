using System;
using System.Globalization;
using Frank.Apps.StarMap.Pages;
using Frank.Apps.StarMap.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Frank.Apps.StarMap;

public class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddDbContext<DataContext>();

                services.AddScoped<App>();

                services.AddScoped<ICsvContext, CsvContext>();

                services.AddScoped<StarListPage>();
                services.AddScoped<StarMapPage>();
                services.AddScoped<GraphicsPage>();
                services.AddScoped<GamePage>();

                services.AddScoped<HostWindow>();

                services.AddHostedService<WindowHost>(); // Must be added last
            });

        host.Build().Run();
    }
}