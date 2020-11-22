using System;
using System.Windows;
using Frank.Apps.AI.Visualizations.Models;
using Frank.Apps.AI.Visualizations.ViewModels;
using Frank.Apps.AI.Visualizations.Views;
using SimpleInjector;

namespace Frank.Apps.AI.Visualizations
{
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

            container.Register<ConsoleView>();
            container.Register<ConsoleViewModel>();
            container.Register<VisualizerView>();
            container.Register<VisualizerViewModel>();

            container.Register<NaiveBaysModel>();

            container.Verify();

            return container;
        }

        private static void RunApplication(Container container)
        {
            try
            {
                var app = new App();
                //app.InitializeComponent();
                var visualizer = container.GetInstance<VisualizerView>();
                app.Run(visualizer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Log the exception and exit
            }
        }
    }
}
