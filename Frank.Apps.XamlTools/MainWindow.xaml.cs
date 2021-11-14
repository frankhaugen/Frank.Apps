using System.Windows;
using Frank.Apps.XamlTools.XamlConverter;

namespace Frank.Apps.XamlTools;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ConvertButton_OnClick(object sender, RoutedEventArgs e)
    {
        var input = InputBox.Text;

        var converter = new XamlConvertor();
        var output = converter.ConvertToString(input);

        OutputBox.Text = output;
    }
}