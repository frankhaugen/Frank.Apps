using Frank.Apps.Graphics.Assets.Shaders;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Frank.Apps.Graphics;

public class Window : GameWindow
{
    private readonly ShaderContainer _shaderContainer;
    private readonly ILogger<Window> _logger;
    private ProgramHandle _programHandle;

    public Window(ILogger<Window> logger, GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
    {
        _logger = logger;

        _shaderContainer = new ShaderContainer();
    }

    private readonly Positions _vertices = new(new Vector3(-0.5f, -0.5f, 0.0f), new Vector3(0.5f, -0.5f, 0.0f), new Vector3(0.5f, 0.5f, 0.0f));

    protected override void OnLoad()
    {
        _programHandle = _shaderContainer.ProgramHandle;
        base.OnLoad();
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        //_logger.LogInformation(ShaderContainer.GetShader("BasicShader").ToString());
        KeyboardState.IsKeyDown(Keys.D);

        GL.UseProgram(_programHandle);

        GL.ClearColor(Color4.Skyblue);
        GL.Clear(ClearBufferMask.ColorBufferBit);
        
        Something(_vertices, BufferTargetARB.ArrayBuffer, PrimitiveType.Triangles, BufferUsageARB.StaticDraw);

        SwapBuffers();
        base.OnRenderFrame(e);
    }

    private void Something(Positions positions, BufferTargetARB bufferTarget, PrimitiveType primitiveType, BufferUsageARB bufferUsage)
    {
        var vertexArray = GL.GenVertexArray();
        var verteciesBuffer = GL.GenBuffer();

        GL.BindVertexArray(vertexArray);
        GL.BindBuffer(bufferTarget, verteciesBuffer);

        GL.BufferData(bufferTarget, positions.GetVerticesAsFloats(), bufferUsage);
        GL.EnableVertexAttribArray(0);
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

        GL.DrawArrays(primitiveType, 0, positions.GetCount());

        GL.BindBuffer(bufferTarget, verteciesBuffer);
        GL.BindVertexArray(vertexArray);
        GL.DeleteVertexArray(vertexArray);
        GL.DeleteBuffer(verteciesBuffer);
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        if (KeyboardState.IsKeyDown(Keys.Escape))
        {
            Close();
        }

        base.OnUpdateFrame(e);
    }
}

public class Drawer
{
    public void DrawTriangle()
    {

    }

    private void Draw()
    {

    }
}