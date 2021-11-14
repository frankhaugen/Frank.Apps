using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace Frank.Apps.Graphics;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly ILogger<Window> _windowLogger;

    private readonly GameWindowSettings _gameWindowSettings = GameWindowSettings.Default;
    private readonly NativeWindowSettings _nativeWindowSettings = NativeWindowSettings.Default;

    public Worker(ILogger<Worker> logger, ILogger<Window> windowLogger)
    {
        _logger = logger;
        _windowLogger = windowLogger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _gameWindowSettings.IsMultiThreaded = false;
        _gameWindowSettings.RenderFrequency = 60;
        _gameWindowSettings.UpdateFrequency = 60;

        _nativeWindowSettings.APIVersion = new Version(4, 1, 0);
        _nativeWindowSettings.AutoLoadBindings = true;
        _nativeWindowSettings.Size = new Vector2i(1024, 768);

        using var game = new Window(_windowLogger, _gameWindowSettings, _nativeWindowSettings);
            
        game.Run();
    }
}