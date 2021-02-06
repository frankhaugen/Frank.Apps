using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Frank.Apps.FormSpawner
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISomething _something;

        public Worker(ILogger<Worker> logger, ISomething something)
        {
            _logger = logger;
            _something = something;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"LOG => {DateTime.UtcNow}");
                _something.Increment();

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}