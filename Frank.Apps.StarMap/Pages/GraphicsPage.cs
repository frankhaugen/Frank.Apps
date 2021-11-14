using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Windows.Controls;
using SciChart.Core.Extensions;
using ScottPlot;
using ScottPlot.Plottable;

namespace Frank.Apps.StarMap.Pages;

public class GraphicsPage : Page
{
    public GraphicsPage()
    {
        Title = "Graphics";
        var physics = new Physics();

        var points = new List<Vector2>();
        var position = new Vector2(0, 0);
            
        for (int i = 0; i < 20; i++)
        {
            position = physics.Trajectory(position, i, 45f, 100f);
            points.Add(position);
        }

        var xValues = points.Select(x => x.X.ToDouble()).ToArray();
        var yValues = points.Select(x => x.Y.ToDouble()).ToArray();

        var signalPlot = new ScatterPlot(xValues, yValues) { };


        var wpfPlot = new WpfPlot();
        var plot = new Plot();

        plot.Add(signalPlot);

        wpfPlot.Plot.Add(signalPlot);

        var view = new Grid();

        view.Children.Add(wpfPlot);

        Content = view;
    }

}

public readonly record struct GameSettings(TimeSpan FrameDelay);
public readonly record struct GameObjectSettings(Vector2 Position, Vector2 Size);

public interface IGame
{
    
}