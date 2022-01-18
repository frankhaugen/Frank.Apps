using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Xna.Framework;

namespace Frank.Apps.QuickEngine;

// USEFUL: https://gist.github.com/aethercowboy/163c52da5c277620e257cfe980e73b8e

public class Runner : BackgroundService
{
    public static GraphicsDeviceManager Graphics;

    private readonly ILogger<Runner> _logger;
    private readonly IGame _game;

    public Runner(ILogger<Runner> logger, IGame game)
    {
        _logger = logger;
        _game = game;
        Graphics = new GraphicsDeviceManager(_game.Game);

        _game.Exiting += Exit;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Game started at: {time}", DateTime.UtcNow);
        _game.Run();
    }

    private void Exit(object sender, EventArgs e)
    {
        _game.Exit();
        _game.Dispose();
        StopAsync(new CancellationToken()).GetAwaiter().GetResult();
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Game stopped at: {time}", DateTime.UtcNow);
        await base.StopAsync(cancellationToken);
    }
}