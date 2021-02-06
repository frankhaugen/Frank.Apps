using System.Windows.Forms;
using Frank.Libraries;

namespace Frank.Apps.FormSpawner
{
    public class SpawnedWindow : Form
    {
        private readonly ITime _time;
        private readonly ISomething _something;

        public SpawnedWindow(ITime time, ISomething something)
        {
            _time = time;
            _something = something;


            var stack = new FlowLayoutPanel();

            var button = new Button() { Text = "Get Week" };
            button.Click += (sender, args) => MessageBox.Show($"Week number => {_time.Now}");
            var button2 = new Button() { Text = "Get Count" };
            button2.Click += (sender, args) => _something.Increment();

            stack.Controls.Add(button);
            stack.Controls.Add(button2);

            Controls.Add(stack);

            _something.ValueChanged += (sender, args) => MessageBox.Show(_something.GetCount().ToString());
        }
    }
}