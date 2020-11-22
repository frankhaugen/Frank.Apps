using System.Windows;
using Frank.Apps.AI.Visualizations.ViewModels;

namespace Frank.Apps.AI.Visualizations.Views
{
    /// <summary>
    /// Interaction logic for ConsoleView.xaml
    /// </summary>
    public partial class ConsoleView : Window
    {
        public ConsoleView(ConsoleViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
