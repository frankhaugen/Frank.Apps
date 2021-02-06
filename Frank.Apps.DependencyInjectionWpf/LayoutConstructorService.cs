using System.Windows.Controls;
using System.Windows.Controls.Ribbon;

namespace Frank.Apps.DependencyInjectionWpf
{
    public class LayoutConstructorService : ILayoutConstructorService
    {
        public LayoutConstructorService()
        {
            Layout = new MainLayout { MenuRibbon = new Ribbon(), RootGrid = new Grid() };
            Layout.RootGrid.Children.Add(Layout.MenuRibbon);
        }

        public MainLayout Layout { get; private set; }
    }
}