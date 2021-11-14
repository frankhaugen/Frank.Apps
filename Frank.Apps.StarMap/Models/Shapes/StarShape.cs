using System.Windows.Shapes;

namespace Frank.Apps.StarMap.Models.Shapes;

public class StarShape
{
    public Ellipse Shape { get; private set; }

    public StarShape()
    {

        Shape = new Ellipse()
        {

        };
    }
}