using Frank.Apps.Loggers;
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
        services.AddHostedService<Worker>();
        services.AddLogging(z => z.AddSeq());
    })
    ;

await host.Build().RunAsync();