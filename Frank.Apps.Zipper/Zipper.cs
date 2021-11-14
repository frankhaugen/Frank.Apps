using System.IO;
using System.IO.Compression;

namespace Frank.Apps.Zipper;

public class Zipper
{
    private readonly DirectoryInfo _origin;
    private readonly DirectoryInfo _destination;
    private readonly FileInfo _file;

    public Zipper(DirectoryInfo origin, DirectoryInfo destination, string filename)
    {
        _origin = origin;
        _destination = destination;
        _file = new FileInfo(Path.Combine(_destination.ToString(), filename));
    }

    public void ZipIt()
    {
        _destination.Create();
        if (_file.Exists)
            _file.Delete();
        ZipFile.CreateFromDirectory(_origin.ToString(), _file.ToString());
    }
}