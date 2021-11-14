using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using Frank.Apps.StarMap.Controls;
using Frank.Libraries.Calculators.BeerCalculators;
using Frank.Libraries.Calculators.FluentCalculation;

namespace Frank.Apps.StarMap.Pages;

public class GamePage : Page
{
    private readonly DispatcherTimer _dispatcherTimer;
    private readonly GameSettings _gameSettings;
    private readonly GameObjectSettings _thingSetting;
    private readonly Rectangle _rectangle;
    private readonly Canvas _canvas;
    private readonly Physics _physics;
    private readonly TextBox _textBox;

    public Color Color { get; }
    public Size Size { get; }
    public Vector2 Position { get; set; }
    public TimeSpan TimeSpan { get; set; }
    public int Counter { get; set; } = 1;

    public GamePage()
    {
        Title = "Game";
        _physics = new Physics();
        VerticalAlignment = VerticalAlignment.Center;
        HorizontalAlignment = HorizontalAlignment.Center;
        TimeSpan = TimeSpan.FromSeconds(0.033);
        _textBox = new TextBox();
        _textBox.Background = new SolidColorBrush(Colors.Transparent);
        Canvas.SetLeft(_textBox, 1);
        Canvas.SetTop(_textBox, 1);

        Position = new Vector2(-1f, -1f);
        Size = new Size(5, 5);
        Color = Colors.Aqua;

        _dispatcherTimer = new DispatcherTimer(TimeSpan, DispatcherPriority.Render, GameLoop, Dispatcher.CurrentDispatcher);
        _rectangle = GetRectangle();

        _canvas = Get();

        //_canvas.Background = new SolidColorBrush(Colors.DarkGreen);

        _canvas.Children.Add(_rectangle);
        _canvas.Children.Add(_textBox);
        var view = new Grid();
        view.Children.Add(_canvas);
        Content = view;

        _dispatcherTimer.Start();
    }

    private void GameLoop(object? sender, EventArgs e)
    {
        SetPosition();
        _textBox.Text = Position.ToString();
        Counter++;

        if (Position.Y > 0.01f)
        {
            _dispatcherTimer.Stop();
            MessageBox.Show("Hit");
        }
    }

    private void SetPosition()
    {
        var currentPosition = GetPosition();

        var newPosition = _physics.Trajectory(currentPosition, Counter, 45, 500);
        
        Canvas.SetLeft(_rectangle, newPosition.X.Multiply(0.01f) * -1);
        Canvas.SetTop(_rectangle, newPosition.Y.Multiply(0.01f) * -1);

        Position = GetPosition();
    }

    Vector2 GetPosition() => new(Convert.ToSingle(_rectangle.GetValue(Canvas.LeftProperty)), Convert.ToSingle(_rectangle.GetValue(Canvas.TopProperty)));


    public Rectangle GetRectangle()
    {
        var rectangle = new Rectangle()
        {
            Tag = Name,
            RenderSize = Size,
            Height = Size.Height,
            Width = Size.Width,
            Fill = new SolidColorBrush(Color),
            Cursor = Cursors.Hand,
            RenderTransform = GetTransform(),
            ToolTip = new ToolTip() { Content = ToString() }
        };

        Canvas.SetLeft(rectangle, Position.X.Multiply(10));
        Canvas.SetTop(rectangle, Position.Y.Multiply(10));

        return rectangle;
    }
    private PanAndZoomCanvas Get()
    {
        PanAndZoomCanvas canvas = new()
        {
            Name = "gridPattern",
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Background = new SolidColorBrush(Colors.MidnightBlue),
            SnapsToDevicePixels = true,
            RenderTransformOrigin = new Point(.5, .5),
            LayoutTransform = new ScaleTransform(-1, 1, .5, -.5),
        };

        return canvas;
    }
    private TranslateTransform GetTransform(double gravityModifier = 0)
    {
        return new TranslateTransform((Size.Width / 2) * -1, (Size.Height / 2) * -1);
    }
}