using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Frank.Apps.UblGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var stackPanel = new StackPanel();

            stackPanel.Children.Add(new Button() { Content = "Button" });
            stackPanel.Children.Add(new Label() { Content = "Label" });

            //var grid = new PermssionRowGrid(5, 5);
            var grid = new Grid();

            foreach (var columnDefinition in getColumnDefinitions(5))
            {
                grid.ColumnDefinitions.Add(columnDefinition);
            }

            foreach (var rowDefinition in getRowDefinitions(5))
            {
                grid.RowDefinitions.Add(rowDefinition);
            }

            TheTextBlock.Text = XamlSerializerUtility.SerializeToXAML(grid);
        }

        private List<ColumnDefinition> getColumnDefinitions(int count = 1)
        {
            var output = new List<ColumnDefinition>();
            if (count < 2)
            {
                count = 1;
            }

            for (int i = 0; i < count; i++)
            {
                output.Add(new ColumnDefinition() { Width = GridLength.Auto });
            }

            return output;
        }

        private List<RowDefinition> getRowDefinitions(int count = 1)
        {
            var output = new List<RowDefinition>();
            if (count < 1)
            {
                count = 1;
            }

            for (int i = 0; i < count; i++)
            {
                output.Add(new RowDefinition() { Height = GridLength.Auto });
            }

            return output;
        }
    }
}
