using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Frank.Apps.StarMap.Controls;
using Frank.Apps.StarMap.Repositories;
using Frank.Apps.StarMap.Services;
using Microsoft.EntityFrameworkCore;

namespace Frank.Apps.StarMap.Pages;

public class StarMapPage : Page
{
    private readonly Canvas _canvas;

    public StarMapPage(DataContext dataContext)
    {
        Title = "Starmap";
        VerticalAlignment = VerticalAlignment.Center;
        HorizontalAlignment = HorizontalAlignment.Center;
        Background = new SolidColorBrush(Color.FromRgb(47, 21, 71));

        _canvas = Get();

        dataContext.Stars
            .AsNoTracking()
            .OrderBy(x => x.Dist)
            //.Skip(1)
            .Take(100)
            .Select(x => new StarInfo(x))
            .ToList()
            .ForEach(x => _canvas.Children.Add(x.GetEllipse()))
            ;

        Content = _canvas;
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
}