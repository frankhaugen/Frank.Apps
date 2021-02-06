using System;
using System.Threading.Tasks;
using Frank.Libraries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Frank.Apps.FormSpawner
{
    public class Program
    {
        //[STAThread]
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Starting");
            await Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<SpawnedWindow>();
                    services.AddSingleton<ISomething, Something>();
                    services.AddHostedService<WindowHost>();
                    services.AddHostedService<Worker>();
                    services.AddScoped<ITime, Time>();
                }).RunConsoleAsync();
        }
    }
}
