using Frank.Apps.Loggers;
using Frank.Apps.Loggers.LoggingProviders.EntityFramework;
using Frank.Apps.Loggers.LoggingProviders.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

IHostBuilder host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        //services.AddSingleton<EntityFrameworkLoggerConfiguration>(new EntityFrameworkLoggerConfiguration()
        //{
        //    LogLevel = LogLevel.Information
        //});
        services.AddDbContext<DataContext>(x => x.UseSqlServer("Server=.\\SQLEXPRESS;Database=LoggingDatabase;Trusted_Connection=True;"));
        services.AddHostedService<Worker>();
        services.Configure<EntityFrameworkLoggerConfiguration>(hostContext.Configuration.GetSection(nameof(EntityFrameworkLoggerConfiguration)));
        services.AddLogging(x => x.AddEntityFrameworkLogger<DataContext>(configuration => configuration.LogLevel = LogLevel.Information));
    });

await host.Build().RunAsync();