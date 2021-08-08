using System.Windows;
using System.Windows.Controls;
using Frank.Apps.StarMap.Pages;

namespace Frank.Apps.StarMap
{
    public class HostWindow : Window
    {
        private StackPanel _content = new();

        public HostWindow(StarListPage starListPage, StarMapPage starMapPage)
        {
            SizeToContent = SizeToContent.WidthAndHeight;

            var grid = new Grid();
            grid.MinWidth = 1024;
            grid.MinHeight = 512;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            grid.Children.Add(GetTabControl(starMapPage, starListPage));

            _content.Children.Add(grid);

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
