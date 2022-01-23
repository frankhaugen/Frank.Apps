using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Frank.Apps.Loggers;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private long _counter = 0;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        const int threads = 50;

        //var listActions = new List<Action>();
        var listActions = new List<int>();

        for (var i = 0; i < threads; i++)
        {
            listActions.Add(i);
            //listActions.Add(async () => await GoNuts(i, stoppingToken));
        }

        var actions = listActions.ToArray();
        _logger.LogWarning("{counter}\t=> Running at: {time}", _counter, DateTime.UtcNow);

        await Task.Delay(2000, stoppingToken);


        Parallel.ForEach(listActions, async index => await GoNuts(index, stoppingToken));

        //var chunks = listActions.Chunk(10);

        //await Parallel.ForEachAsync(chunks, stoppingToken, async action => await GoNuts(action, stoppingToken));

        //for (var i = 0; i < threads; i++)
        //{
        //    //var threadId = int.Parse(i.ToString());
        //    Task.Run(() => GoNuts(i, stoppingToken), stoppingToken);
        //}
    }

    private async Task GoNuts(int thread, CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("{Thread}\t{counter}\t=> {time}", thread, _counter, DateTime.UtcNow);
            try
            {
                await Task.Run(() => _counter++);
            }
            catch
            {
                await Task.Delay(1, stoppingToken);
            }
            await Task.Delay(1, stoppingToken);
        }
    }
}