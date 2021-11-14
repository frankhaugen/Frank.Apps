using System;
using System.Windows.Input;

namespace Frank.Apps.AI.Visualizations.Commands;

public class ChangePlotCommand : ICommand
{
    private Action<object> _action;

    public ChangePlotCommand(Action<object> action)
    {
        _action = action;
    }

    /// <inheritdoc />
    public bool CanExecute(object? parameter) => true;

    /// <inheritdoc />
    public void Execute(object? parameter)
    {
        if (parameter != null)
        {
            _action(parameter);
        }
        else
        {
            _action("Hello world");
        }
    }

    /// <inheritdoc />
    public event EventHandler CanExecuteChanged;
}