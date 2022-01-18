using Frank.Apps.QuickEngine.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Frank.Apps.QuickEngine;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {

                services.Configure<GameOptions>(hostContext.Configuration.GetSection(nameof(GameOptions)));

                services.AddSingleton<IGame, MainGame>();
                services.AddHostedService<Runner>();
            });
}