using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Frank.Apps.SecurityCam;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        getListCameraUSB();
    }

    private void getListCameraUSB()
    {
        _logger.LogInformation("wrgrg");
        //var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

        //if (videoDevices.Count != 0)
        //{
        // add all devices to combo
        //foreach (FilterInfo device in videoDevices)
        //{
        //comboBox1.Items.Add(device.Name);
        //    _logger.LogInformation(device.MonikerString + " - " + device.Name);
        //}
        //}
        //else
        //{
        //comboBox1.Items.Add("No DirectShow devices found");
        //}

        //comboBox1.SelectedIndex = 0;

    }
}