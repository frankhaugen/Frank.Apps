namespace Frank.Apps.StarMap.Models;

public class StarModel : SphereGeometry3D
{
    public StarModel()
    {
        Radius = 1;
        Separators = 10;
    }
}