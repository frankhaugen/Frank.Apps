using System;

namespace Frank.Apps.FormSpawner;

public interface ISomething
{
    event EventHandler ValueChanged;
    void Increment();
    int GetCount();
}