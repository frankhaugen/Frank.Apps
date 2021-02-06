using System;
using Frank.Libraries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Frank.Apps.WindowSpawner
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<SpawnedWindow>();
                    //services.AddSingleton<ISomething, Something>();
                    services.AddHostedService<WindowHost>();
                    //services.AddHostedService<Worker>();
                    services.AddScoped<ITime, Time>();
                }).Build().Start();
        }
    }
}
