using System;
using System.Threading;
using System.Threading.Tasks;
using Cronos;
using Frank.Libraries.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Frank.Apps.Scheduler;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            var cron = CronExpression.Parse("", CronFormat.IncludeSeconds);

            var time = cron.GetNextOccurrence(DateTime.UtcNow);

            await Task.Delay(1000, stoppingToken);
        }
    }
}

public class TheThing : JsonEntity
{
    public string CronQuery { get; set; }
    public bool Running { get; set; }
}