using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Frank.Libraries.AzureStorage;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Frank.Apps.AzureStorage;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly BlobService _blobService;

    public Worker(ILogger<Worker> logger, BlobService blobService)
    {
        _logger = logger;
        _blobService = blobService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

        var file = new FileInfo("MicrosoftLogo.jpg");
        var success = await _blobService.DeleteAsync(file.Name);

        _logger.LogInformation($"Success: {success}");
    }
}