using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Frank.Apps.InputDetector;

public class WindowHost : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<WindowHost> _logger;

    public WindowHost(IServiceProvider serviceProvider, ILogger<WindowHost> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Started");

        using var scope = _serviceProvider.CreateScope();
        var window = scope.ServiceProvider.GetRequiredService<MainWindow>();
        var app = scope.ServiceProvider.GetRequiredService<App>();
        app.Run(window);
    }
}