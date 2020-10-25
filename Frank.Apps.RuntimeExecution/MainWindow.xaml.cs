using System;
using System.Windows;
using System.Windows.Input;

namespace Frank.Apps.RuntimeExecution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CodeExecuter _codeExecuter;

        public MainWindow()
        {
            InitializeComponent();
            _codeExecuter = new CodeExecuter();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var code = Editor.Text;
            var result = await _codeExecuter.RoslynScriptingAsync(code);
            MessageBox.Show(result);
        }
    }
}
