using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace Frank.Apps.Sudoku.Models;

public class Cell
{
    public Cell(Position position)
    {
        Position = position;
        var textBox = new TextBox();
        Grid.SetColumn(textBox, Position.X);
        Grid.SetRow(textBox, Position.Y);
        textBox.ToolTip = GetName();
        textBox.Background = new SolidColorBrush(Colors.DarkSlateGray);
        textBox.Text = Value.ToString();
        textBox.TextChanged += (sender, args) => Value = Int32.Parse(sender.As<TextBox>().Text);

        TextBox = textBox;
    }

    public TextBox TextBox { get; set; }
    public Position Position { get; set; }
    public int Value { get; set; }
    public string GetName() => $"{Position.X},{Position.Y}";
}

public static class ObjectExtensions
{
    public static T As<T>(this object source) => (T)source;
}