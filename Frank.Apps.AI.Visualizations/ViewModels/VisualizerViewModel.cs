using System;
using System.Windows;
using System.Windows.Input;
using Frank.Apps.AI.Visualizations.Commands;
using Frank.Apps.AI.Visualizations.Models;
using ScottPlot;

namespace Frank.Apps.AI.Visualizations.ViewModels
{
    public class VisualizerViewModel
    {
        private readonly NaiveBaysModel _baysModel;

        private WpfPlot _plot = new WpfPlot();

        public WpfPlot Plot => _plot;

        public VisualizerViewModel(NaiveBaysModel baysModel)
        {
            _baysModel = baysModel;
            _plot.plt.PlotSignal(DataGen.RandomWalk(new Random(), 1000));
            _plot.Render();
        }

        public ICommand ChangePlot => new ChangePlotCommand(o => ChangingPlot());

        private void ChangingPlot()
        {
            _plot.plt.Clear();
            _plot.plt.PlotPie(DataGen.RandomWalk(new Random(), 10));
            //_plot.plt.Add(new PlottableText(_baysModel.Run(), 0.0, 0.0, Color.BlanchedAlmond, FontFamily.GenericMonospace.Name, ));
            _plot.Render();
            MessageBox.Show(_baysModel.Run());
        }
    }
}
