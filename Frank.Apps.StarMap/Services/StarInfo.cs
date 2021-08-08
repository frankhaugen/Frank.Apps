using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Frank.Apps.StarMap.Models;

namespace Frank.Apps.StarMap.Services
{
    public class StarInfo
    {
        private readonly Star _star;

        public StarInfo(Star star)
        {
            _star = star;

            Color = DetermineStarColor(star.Spect);
            Size = DetermineStarSize(star.Spect);
            Spectrum = star.Spect;
            Name = GetName(star);
            Position = new Vector3((float)star.X, (float)star.Y, (float)star.Z);
        }

        public Ellipse GetEllipse()
        {
            var ellipse = new Ellipse()
            {
                Tag = Name,
                RenderSize = Size,
                Height = Size.Height,
                Width = Size.Width,
                Fill = new SolidColorBrush(Color),
                Cursor = Cursors.Hand,
                RenderTransform = new TranslateTransform((Position.X / 2), (Position.Y / 2)),
                ToolTip = new ToolTip() { Content = ToString() }
            };

            ellipse.SetValue(Canvas.LeftProperty, (double)Position.X * 100);
            ellipse.SetValue(Canvas.TopProperty, (double)Position.Y * 100);
            //ellipse.SetValue(Panel.ZIndexProperty, (double)(((Size.Height + Size.Width) / 2) * -1));

            return ellipse;
        }

        public override string ToString() =>
            new StringBuilder()
                .AppendLine($"{Name}")
                .AppendLine($"Catalog no: {_star.Gl}, HD: {_star.Hd}")
                .AppendLine($"Location: {_star.X},{_star.Y},{_star.Z}")
                .ToString();

        public Color Color { get; }
        public Size Size { get; }
        public Vector3 Position { get; }
        public string Spectrum { get; }
        public string Name { get; }

        private static string GetName(Star star)
        {
            if (!string.IsNullOrWhiteSpace(star.Proper))
                return star.Proper;
            if (!string.IsNullOrWhiteSpace(star.Bf))
                return star.Bf;
            if (string.IsNullOrWhiteSpace(star.Gl))
                return star.Gl;
            return "";
        }

        private Color DetermineStarColor(string spectrum)
        {
            if (spectrum.Contains("O")) return Colors.Blue;
            if (spectrum.Contains("B")) return Colors.DeepSkyBlue;
            if (spectrum.Contains("A")) return Colors.LightBlue;
            if (spectrum.Contains("F")) return Colors.White;
            if (spectrum.Contains("G")) return Colors.LightGoldenrodYellow;
            if (spectrum.Contains("K")) return Colors.Orange;
            if (spectrum.Contains("M")) return Colors.Red;
            return Colors.Brown;
        }

        private Size DetermineStarSize(string spectrum)
        {
            if (spectrum.Contains("O")) return new Size(23, 23);
            if (spectrum.Contains("B")) return new Size(19, 19);
            if (spectrum.Contains("A")) return new Size(17, 17);
            if (spectrum.Contains("F")) return new Size(13, 13);
            if (spectrum.Contains("G")) return new Size(9, 9);
            if (spectrum.Contains("K")) return new Size(7, 7);
            if (spectrum.Contains("M")) return new Size(5, 5);
            return new Size(3, 3);
        }
    }
}
