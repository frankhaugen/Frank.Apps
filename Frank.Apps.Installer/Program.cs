using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;

namespace Frank.Apps.Installer;

class Program
{
    static async Task<int> Main(string[] args)
    {
        //if (args.Length < 2)
        //{
        //    Console.WriteLine("Two args required: source destination");
        //    Console.ReadLine();
        //    Environment.Exit(1);
        //}

        return await Parser.Default.ParseArguments<CommandLineOptions>(args)
            .MapResult(async (CommandLineOptions opts) =>
                {
                    try
                    {
                        var sourceDirectory = new DirectoryInfo(opts.Source);
                        var destinationDirectory = new DirectoryInfo(opts.Destination);

                        if (!sourceDirectory.Exists || !destinationDirectory.Exists || sourceDirectory.EnumerateFiles().All(x => x.Extension != ".exe"))
                        {
                            Console.WriteLine("Error!");
                            return -3;
                        }

                        var applicationFile = sourceDirectory.EnumerateFiles().FirstOrDefault(x => x.Extension == ".exe");

                        var applicationName = Path.GetFileNameWithoutExtension(applicationFile?.FullName);
                        var destinationFullName = Path.Combine(destinationDirectory.FullName, applicationName + ".zip");

                        ZipFile.CreateFromDirectory(sourceDirectory.FullName, destinationFullName);

                        if (opts.ZipToDestination)
                            return 0;

                        ZipFile.ExtractToDirectory(destinationFullName, destinationDirectory.FullName);

                        var zipFile = new FileInfo(destinationFullName);

                        if (zipFile.Exists) zipFile.Delete();

                        return 0;
                    }
                    catch
                    {
                        Console.WriteLine("Error!");
                        return -3; // Unhandled error
                    }
                },
                errs => Task.FromResult(-1));
    }
}

public class CommandLineOptions
{
    [Value(index: 0, Required = true, HelpText = "Source path")]
    public string Source { get; set; }

    [Value(index: 1, Required = true, HelpText = "Destination path")]
    public string Destination { get; set; }

    [Option(shortName: 'z', longName: "zip", Required = false, HelpText = "Zip file in destination", Default = false)]
    public bool ZipToDestination { get; set; }
}