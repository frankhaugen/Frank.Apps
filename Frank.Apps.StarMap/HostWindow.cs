using System.Windows;
using System.Windows.Controls;
using Frank.Apps.StarMap.Pages;

namespace Frank.Apps.StarMap
{
    public class HostWindow : Window
    {
        private Grid _content = new();

        public HostWindow(GamePage gamePage, GraphicsPage graphicsPage, StarListPage starListPage, StarMapPage starMapPage)
        {
            MinWidth = 1024;
            MinHeight = 512;
            MaxHeight = MinHeight * 2;
            MaxWidth = MinWidth * 2;

            SizeToContent = SizeToContent.WidthAndHeight;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            _content.Children.Add(GetTabControl(gamePage, graphicsPage, starMapPage, starListPage));

            Content = _content;
        }

        private TabControl GetTabControl(params Page[] pages)
        {
            var output = new TabControl();

            foreach (var page in pages)
            {
                output.Items.Add(new TabItem() { Header = page.Title, Content = new Frame() { Content = page } });
            }

            return output;
        }
    }
}
