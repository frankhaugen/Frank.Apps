using System;

namespace Frank.Apps.WindowSpawner
{
    public interface ISomething
    {
        event EventHandler ValueChanged;
        void Increment();
        int GetCount();
    }
}