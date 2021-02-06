using System;
using System.Windows;
using System.Windows.Controls;
using Frank.Libraries;

namespace Frank.Apps.WindowSpawner
{
    public class SpawnedWindow : Window
    {
        private readonly ITime _time;
        private readonly ISomething _something;

        private Label counter;

        public SpawnedWindow(ITime time, ISomething something)
        {
            _time = time;
            _something = something;

            counter = new Label() { Content = "Get Count" };

            var stack = new StackPanel();

            var button = new Button() { Content = "Get Week" };
            button.Click += (sender, args) => MessageBox.Show($"Week number => {_time.Now}");

            stack.Children.Add(counter);
            stack.Children.Add(button);

            Content = stack;

            _something.ValueChanged += OnSomethingOnValueChanged;
        }

        private void OnSomethingOnValueChanged(object? sender, EventArgs args)
        {
            counter.Content = _something.GetCount().ToString();
        }
    }
}