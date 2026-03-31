using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SharpHook;

namespace Frank.Apps.InputDetector;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var hook = new SimpleGlobalHook();
        hook.KeyPressed += (sender, e) =>
        {
            _logger.LogInformation("Keyboard Hook: {0}", e.Data);
        };
        await hook.RunAsync();

        //using var aggHandler = new AggregateInputReader();
        //aggHandler.OnKeyPress += (e) => { System.Console.WriteLine($"Code:{e.Code} State:{e.State}"); };

        //while (!stoppingToken.IsCancellationRequested)
        //{
        //    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        //    await Task.Delay(1000, stoppingToken);
        //}
    }
}