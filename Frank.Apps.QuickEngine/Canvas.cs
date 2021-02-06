using System.Numerics;
using System.Windows;

namespace Frank.Apps.QuickEngine
{
    public class Canvas : Window
    {
        public Canvas()
        {
            
        }
    }

    public class Engine
    {
        private readonly Vector2 _screenSize;
        private readonly Canvas _canvas;

        public Engine(Vector2 screenSize)
        {
            _screenSize = screenSize;

            _canvas = new Canvas();

            _canvas.Width = _screenSize.X;
            _canvas.Height = _screenSize.Y;

            _canvas.Title = "GAME!";

            _canvas.Show();
        }
    }
}
