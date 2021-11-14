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

    public class Physics
    {
        public Vector2 Trajectory(Vector2 origin, int instant, float launchAngle, float initialVelocity)
        {

            Vector2 vector2 = new Vector2(0, 0);

            vector2.X = CalculateHorizontalVelocity(instant, initialVelocity, launchAngle);
            vector2.Y = CalculateVerticalVelocity(instant, initialVelocity, launchAngle);
            return vector2;
        }
        public static float CalculateHorizontalVelocity(int instant, float initialVelocity, float launchAngle)
        {
            return initialVelocity * MathF.Cos(launchAngle) * instant;
        }
        public static float CalculateVerticalVelocity(int instant, float initialVelocity, float launchAngle)
        {
            return initialVelocity * MathF.Sin(launchAngle) * instant - 0.5F * 9.81F * instant * instant;
        }
    }
}