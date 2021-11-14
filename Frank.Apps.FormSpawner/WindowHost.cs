using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Frank.Apps.FormSpawner;

public class WindowHost : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public WindowHost(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var window = scope.ServiceProvider.GetRequiredService<SpawnedWindow>();
        Application.Run(window);
    }
}