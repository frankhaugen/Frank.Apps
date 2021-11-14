using System.Windows;

namespace Frank.Apps.RockPaperScissor;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    //private Action MachineAction()
    //{
    //    var random = new Random();

    //    return random.Next();

    //}
}

public static class EnumExtensions
{
    //public static T Get<T>(this T source, int value) where T : Enum
    //{
    //    return T.Parse(Enum.GetName(typeof(T), value));
    //}
}


public enum Action
{
    Rock,
    Paper,
    Scissor
}