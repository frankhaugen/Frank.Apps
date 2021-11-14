using System.Windows;
using Frank.Apps.VisualNovel.ViewModels;

namespace Frank.Apps.VisualNovel.Views;

/// <summary>
/// Interaction logic for VisualNovelView.xaml
/// </summary>
public partial class VisualNovelView : Window
{
    public VisualNovelView(VisualNovelViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}