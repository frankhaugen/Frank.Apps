using System;
using System.Windows;
using Frank.Apps.VisualNovel.Views;
using SimpleInjector;

namespace Frank.Apps.VisualNovel;

static class Program
{
    [STAThread]
    static void Main()
    {
        var container = Bootstrap();
        RunApplication(container);
    }

    private static Container Bootstrap()
    {
        var container = new Container();

        container.Verify();

        return container;
    }

    private static void RunApplication(Container container)
    {
        try
        {
            var app = new App();
            //app.InitializeComponent();
            var visualizer = container.GetInstance<VisualNovelView>();
            app.Run(visualizer);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            //Log the exception and exit
        }
    }
}