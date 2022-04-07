using Frank.Apps.QuickEngine.Configuration;
using Frank.Apps.QuickEngine.Graphics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Shapes;

namespace Frank.Apps.QuickEngine;

public class MainGame : Game, IGame
{
    public Game Game => this;
    public Vector2 Center { get; private set; }

    private readonly ILogger<MainGame> _logger;
    private readonly IOptions<GameOptions> _options;

    private Camera _camera;

    private SpriteBatch _sprites;
    private SpriteFont _spriteFont;

    public MainGame(ILogger<MainGame> logger, IOptions<GameOptions> options)
    {
        _logger = logger;
        _options = options;

        Content.RootDirectory = "Content";
        IsFixedTimeStep = _options.Value.FixedTimeStep;
        IsMouseVisible = _options.Value.ShowPointer;
        Window.AllowUserResizing = _options.Value.AllowUserResizing;
        Window.ClientSizeChanged += (_, _) => Center = GraphicsDevice.Viewport.Bounds.Center.ToVector2();
    }

    protected override void Initialize() => base.Initialize();

    protected override void LoadContent()
    {
        _sprites = new SpriteBatch(GraphicsDevice);
        _spriteFont = Content.Load<SpriteFont>("Text");


        _camera = new Camera(GraphicsDevice.Viewport);

        base.LoadContent();
    }

    protected override void UnloadContent() => base.UnloadContent();

    protected override void Update(GameTime gameTime)
    {
        Center = GraphicsDevice.Viewport.Bounds.Center.ToVector2();

        _camera.UpdateCamera(GraphicsDevice.Viewport);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _sprites.Begin();
        _sprites.DrawString(_spriteFont, Center.ToString(), Center, Color.Black);


        var a = new Vector2(20);
        var b = Center - new Vector2(20);


        _sprites.DrawString(_spriteFont, a.ToString(), a, Color.Black);
        _sprites.DrawString(_spriteFont, b.ToString(), b, Color.Black);
        _sprites.DrawLine(a, b, Color.AntiqueWhite);

        _sprites.End();

        base.Draw(gameTime);
    }
}