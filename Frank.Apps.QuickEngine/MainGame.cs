using Frank.Apps.QuickEngine.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Frank.Apps.QuickEngine;

public class MainGame : Game, IGame
{
    public Game Game => this;
    public Vector2 Center { get; private set; }

    private readonly ILogger<MainGame> _logger;
    private readonly IOptions<GameOptions> _options;

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

        base.LoadContent();
    }

    protected override void UnloadContent() => base.UnloadContent();

    protected override void Update(GameTime gameTime)
    {
        Center = GraphicsDevice.Viewport.Bounds.Center.ToVector2();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _sprites.Begin();
        _sprites.DrawString(_spriteFont, Center.ToString(), Center, Color.Black);
        _sprites.End();

        base.Draw(gameTime);
    }
}