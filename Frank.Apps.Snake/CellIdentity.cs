using System;
using System.Numerics;
using System.Windows.Controls;
using System.Windows.Media;
namespace Frank.Apps.Snake;

public class CellIdentity
{
    public CellIdentity(int x, int y)
    {
        Id = Guid.NewGuid();

        Position = new Vector2(x, y);
        var label = new Label();
        Grid.SetColumn(label, x);
        Grid.SetRow(label, y);
        label.ToolTip = Position.ToString();
        label.Background = new SolidColorBrush(Colors.DarkSlateGray);

        Label = label;
    }

    public Guid Id { get; }
    public Vector2 Position { get; }
    public Label Label { get; }
    public bool IsSnake { get; set; }
    public bool IsFood { get; set; }

    /// <inheritdoc />
    public override string ToString() => Position.ToString();

    private string GetRandomHexColor()
    {
        var alt1 = $"#{new Random(new Random().Next(0, 1000000) + new Random().Next(1000000, 9000000)).Next(0x1000000):X6}";
        return alt1;
    }
}