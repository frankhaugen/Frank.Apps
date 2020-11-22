using System.Windows;
using Frank.Apps.AI.Visualizations.ViewModels;

namespace Frank.Apps.AI.Visualizations.Views
{
    /// <summary>
    /// Interaction logic for VisualizerView.xaml
    /// </summary>
    public partial class VisualizerView : Window
    {
        public VisualizerView(VisualizerViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
