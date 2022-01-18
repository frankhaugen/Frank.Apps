using System;
using Microsoft.Xna.Framework;

namespace Frank.Apps.QuickEngine;

public interface IGame : IDisposable
{
    Vector2 Center { get; }
    Game Game { get; }

    // include all the Properties/Methods that you'd want to use on your Game class below.
    GameWindow Window { get; }

    event EventHandler<EventArgs> Exiting;

    void Run();
    void Exit();
}