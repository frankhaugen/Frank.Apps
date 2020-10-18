using System;
using System.IO;
using System.Reflection;

namespace Frank.Apps.BuildTool.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var assemplyFile = new FileInfo(Assembly.GetExecutingAssembly().Location);
            var assemblyDirectory = assemplyFile.Directory;

            var msBuildTool = new MsBuildTool();

            }

        // dotnet publish -r win-x64 -o "..\Builds" -c Release --self-contained --source https://api.nuget.org/v3/index.json -p:PublishReadyToRun=true -p:PublishSingleFile=true -p:PublishTrimmed=true
    }
}
