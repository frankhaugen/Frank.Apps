using System.Windows;

namespace Frank.Apps.DependencyInjectionWpf;

public class MainWindow : Window
{
    private readonly ILayoutConstructorService _layoutConstructorService;
    public MainWindow(ILayoutConstructorService layoutConstructorService)
    {
        _layoutConstructorService = layoutConstructorService;

        Content = _layoutConstructorService.Layout.RootGrid;
    }
}