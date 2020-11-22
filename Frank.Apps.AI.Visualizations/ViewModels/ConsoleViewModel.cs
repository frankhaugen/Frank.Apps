using System.Collections.ObjectModel;

namespace Frank.Apps.AI.Visualizations.ViewModels
{
    public class ConsoleViewModel
    {
        private protected readonly ObservableCollection<string> _output;

        public ObservableCollection<string> Output => _output;

        public ConsoleViewModel()
        {
            _output = new ObservableCollection<string>();
        }

        public void AddToOutput(string output)
        {
            _output.Add(output);
        }
    }
}
