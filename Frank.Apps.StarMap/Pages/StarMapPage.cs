using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Frank.Apps.StarMap.Controls;
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
            Background = new SolidColorBrush(Color.FromRgb(47, 21, 71));

            //_slider = Get2();
            _canvas = Get();

            dataContext.Stars
                .AsNoTracking()
                .OrderBy(x => x.Dist)
                .Skip(1)
                .Take(10)
                .Select(x => new StarInfo(x))
                .ToList()
                .ForEach(x => _canvas.Children.Add(x.GetEllipse()))
                ;

            var grid = new Grid
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            //MouseWheel += Canvas_MouseWheel;

            //grid.Children.Add(_canvas);

            //_canvas.SetBinding(DependencyProperty.Register(grid.Name, ), "Height");

            Content = grid;
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
                //Height = 0,
                //Width = 0,
                RenderTransformOrigin = new Point(.5, .5),
                LayoutTransform = new ScaleTransform(-1, 1, .5, -.5),
            };

            return canvas;
        }

        private Canvas Get3()
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

        // Zoom
        private double zoomMax = 25;
        private double zoomMin = 0.25;
        private double zoomSpeed = 0.001;
        private double zoom = 1;

        // Zoom on Mouse wheel
        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            zoom += zoomSpeed * e.Delta; // Ajust zooming speed (e.Delta = Mouse spin value )
            if (zoom < zoomMin) { zoom = zoomMin; } // Limit Min Scale
            if (zoom > zoomMax) { zoom = zoomMax; } // Limit Max Scale

            Point mousePos = e.GetPosition(_canvas);

            if (zoom > 1)
            {
                _canvas.RenderTransform = new ScaleTransform(zoom, zoom, mousePos.X, mousePos.Y); // transform Canvas size from mouse position
            }
            else
            {
                _canvas.RenderTransform = new ScaleTransform(zoom, zoom); // transform Canvas size
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
