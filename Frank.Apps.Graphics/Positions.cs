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

public readonly record struct Vertex(Vector4 Position, Color4<Rgba> Color)
{
    public int GetSize() => 4 * 2 * sizeof(float);
}