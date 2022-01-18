using OpenTK.Mathematics;

namespace Frank.Apps.Graphics;

public readonly record struct Positions(params Vector3[] Verticies)
{
    public int GetCount() => Verticies.Length;
    public Vector3[] GetVertices() => Verticies;

    public float[] GetVerticesAsFloats()
    {
        var output = new List<float>();
        if (Verticies != null && Verticies.Any())
        {
            foreach (var (x, y, z) in Verticies)
            {
                output.Add(x);
                output.Add(y);
                output.Add(z);
            }
        }
        else
        {
            output.Add(0.0f);
            output.Add(0.0f);
            output.Add(0.0f);
        }
        return output.ToArray();
    }
}


public readonly record struct Polygon(Vector3 Position1, Vector3 Position2, Vector3 Position3)
{
    public int GetCount() => GetVertices().Length;
    public Vector3[] GetVertices() => new[] { Position1, Position2, Position3 };

    public float[] GetVerticesAsFloats()
    {
        var output = new List<float>();

        foreach (var (x, y, z) in GetVertices())
        {
            output.Add(x);
            output.Add(y);
            output.Add(z);
        }

        return output.ToArray();
    }
}

public readonly record struct Vertex(Vector4 Position, Color4<Rgba> Color)
{
    public int GetSize() => 4 * 2 * sizeof(float);
}