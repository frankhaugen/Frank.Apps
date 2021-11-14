using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Frank.Apps.YouTube;

public class WindowHost : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public WindowHost(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        //using var scope = _serviceProvider.CreateScope();
        //var window = scope.ServiceProvider.GetRequiredService<IntegrationAgentWindow>();
        //var app = scope.ServiceProvider.GetRequiredService<App>();
        //window.Closed += (sender, args) => Environment.Exit(666);

        //app.Run(window);
    }
}