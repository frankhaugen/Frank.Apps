using System;
using System.ComponentModel;

namespace Frank.Apps.FormSpawner
{
    public class Something : ISomething
    {
        private int counter = 0;

        [Category("Action")]
        [Description("Fires when the value is changed")]
        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged(EventArgs e) => ValueChanged?.Invoke(this, e);

        public void Increment()
        {
            counter += 1;
            OnValueChanged(null);
        }

        public int GetCount() => counter;
    }
}