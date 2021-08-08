using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Frank.Apps.StarMap.Repositories;
using Frank.Apps.StarMap.Services;
using Microsoft.EntityFrameworkCore;
using Point = System.Windows.Point;

namespace Frank.Apps.StarMap.Pages
{
    public class StarMapPage : Page
    {
        private Slider _slider;
        private Canvas _canvas;

        public StarMapPage(DataContext dataContext)
        {
            Title = "Starmap";
            _slider = Get2();
            _canvas = Get();

            dataContext.Stars
                .AsNoTracking()
                .OrderBy(x => x.Dist)
                .Take(50)
                .Select(x => new StarInfo(x))
                .ToList()
                .ForEach(x => _canvas.Children.Add(x.GetEllipse()))
                ;

            var grid = new Grid
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 1024,
                Height = 1024,
                Background = new SolidColorBrush(Colors.MidnightBlue)
            };

            //_slider.MouseDoubleClick += new MouseButtonEventHandler(RestoreScalingFactor); //zoom func

            grid.Children.Add(_canvas);
            grid.Children.Add(_slider);
            Content = grid;
        }

        private Canvas Get()
        {
            Canvas canvas = new()
            {
                Name = "gridPattern",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Background = new SolidColorBrush(Colors.MidnightBlue),
                Height = 0,
                Width = 0,
                RenderTransformOrigin = new Point(.5, .5),
                LayoutTransform = new ScaleTransform(-1, 1, .5, -.5),
            };


            return canvas;
        }


        void RestoreScalingFactor(object sender, MouseButtonEventArgs args)
        {
            ((Slider)sender).Value = 1.0;
        }

        protected override void OnPreviewMouseWheel(MouseWheelEventArgs args)
        {
            base.OnPreviewMouseWheel(args);
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                _slider.Value += (args.Delta > 0) ? 0.1 : -0.1;
            }
        }

        protected override void OnPreviewMouseDown(MouseButtonEventArgs args)
        {
            base.OnPreviewMouseDown(args);
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                if (args.MiddleButton == MouseButtonState.Pressed)
                {
                    RestoreScalingFactor(_slider, args);
                }
            }
        }

        private Slider Get2()
        {
            Slider slider = new Slider
            {
                Name = "uiScaleSlider",
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right,
                ToolTip = "Determines the UI scale factor. Double-click to revert scaling back to 100%.",
                Height = 100D,
                Value = 1D,
                Minimum = 0.1D,
                Maximum = 5D,
                Orientation = Orientation.Vertical,
                Ticks = new DoubleCollection(25),
                IsSnapToTickEnabled = true,
                TickPlacement = TickPlacement.BottomRight,
                AutoToolTipPlacement = AutoToolTipPlacement.BottomRight,
                AutoToolTipPrecision = 2,
                Margin = new Thickness(0, 0, 7, 31)
            };
            return slider;
        }
    }
}
