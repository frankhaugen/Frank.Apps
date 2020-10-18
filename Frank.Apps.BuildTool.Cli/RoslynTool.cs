using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Build.Evaluation;

namespace Frank.Apps.BuildTool.Cli
{
    public class RoslynTool
    {
        public List<FileInfo> GetProjectFiles(DirectoryInfo directory)
        {
            var files = directory.EnumerateFiles("*.csproj", SearchOption.AllDirectories);
            var roslynBuildProjects = new List<FileInfo>();

            foreach (var fileInfo in files)
            {
                try
                {
                    var project = new Project(fileInfo.FullName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(fileInfo.Name);
                    roslynBuildProjects.Add(fileInfo);
                }
            }

            return roslynBuildProjects;
        }
    }
}
