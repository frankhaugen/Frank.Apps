using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Frank.Apps.Graphics.Assets.Shaders;

public class ShaderContainer
{
    private static readonly List <Shader> Shaders = new();

    private const string VertexShaderExtension = ".vert";
    private const string FragmentShaderExtension = ".frag";

    public readonly ProgramHandle ProgramHandle;

    public ShaderContainer()
    {
        ProgramHandle = GL.CreateProgram();

        var shaderDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), nameof(Assets), nameof(Shaders)));

        var directories = shaderDirectory.EnumerateDirectories();
        foreach (var directory in directories)
        {
            ProcessShaderDirectory(directory);    
        }
    }

    private void InitializeShader(Shader shader)
    {
        GL.AttachShader(ProgramHandle, shader.Handle);
        GL.LinkProgram(ProgramHandle);
        GL.DetachShader(ProgramHandle, shader.Handle);
        GL.DeleteShader(shader.Handle);
        GL.GetProgramInfoLog(ProgramHandle, out var programInfoLog);

        if (programInfoLog.Any())
        {
            throw new Exception(programInfoLog);
        }
    }

    private void ProcessShaderDirectory(DirectoryInfo directory)
    {
        foreach (var file in directory.EnumerateFiles())
        {
            CompileAndAddShaderFile(file);
        }
    }

    private void CompileAndAddShaderFile(FileInfo file)
    {
        var shaderType = GetShaderType(file);
        var shaderCode = File.ReadAllText(file.FullName);
        var shaderName = Path.GetFileNameWithoutExtension(file.Name);
        var shaderHandle = GL.CreateShader(shaderType);

        GL.ShaderSource(shaderHandle, shaderCode);
        GL.CompileShader(shaderHandle);

        GL.GetShaderInfoLog(shaderHandle, out var shaderInfo);

        if (shaderInfo.Any())
        {
            throw new Exception(shaderInfo);
        }

        var shader = new Shader(shaderName, shaderType, shaderHandle, shaderCode, file);

        InitializeShader(shader);

        Shaders.Add(shader);
    }

    private ShaderType GetShaderType(FileInfo file) =>
        file.Extension switch
        {
            VertexShaderExtension => ShaderType.VertexShader,
            FragmentShaderExtension => ShaderType.FragmentShader,
            _ => throw new ArgumentOutOfRangeException(nameof(file), $"'{file.FullName}' is not a valid shader file")
        };

    public Shader GetShader(string name) => Shaders.FirstOrDefault(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

    public Shader GetShader(ShaderHandle handle) => Shaders.FirstOrDefault(x => x.Handle.Equals(handle));

    public Shader GetShader(string name, ShaderType type) => Shaders.FirstOrDefault(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) && x.Type == type);
}

//public readonly record struct ShaderData(string Name, ShaderType ShaderType, string ShaderCode);
public readonly record struct Shader(string Name, ShaderType Type, ShaderHandle Handle, string ShaderCode, FileInfo ShaderFile);