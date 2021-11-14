using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using ConsoleTableExt;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Frank.Apps.NetworkScanner;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

        _logger.LogInformation("Worker stopping at: {time}", DateTimeOffset.Now);
    }

    private async Task Old1()
    {
        var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

        ConsoleTableBuilder.From(networkInterfaces.ToList()).WithFormat(ConsoleTableBuilderFormat.Minimal).ExportAndWriteLine();

        var globalProperties = IPGlobalProperties.GetIPGlobalProperties();
        var tcpListeners = globalProperties.GetActiveTcpListeners();

        //ConsoleTableBuilder.From(tcpListeners.ToList()).WithFormat(ConsoleTableBuilderFormat.Minimal).ExportAndWriteLine();


        Parallel.ForEach(tcpListeners, async (tcpListener) =>
        {
            try
            {
                //var host = await Dns.GetHostEntryAsync(tcpListener.Address);
                //Console.WriteLine($"{host.HostName}\t\t\t\t\t\t{tcpListener.Port}\t\t{tcpListener.Address.ToString()}");
            }
            catch (Exception e)
            {
            }
        });
    }
}