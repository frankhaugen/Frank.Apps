using System.Windows;
using System.Windows.Controls;

namespace Frank.Apps.InputDetector
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            var textbox = new TextBlock();

            //ButtonCodeExtensions.ToMouseButtonData()


            Content = textbox;
        }
    }
}
