using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Build.Evaluation;

namespace Frank.Apps.BuildTool.Cli;

public class MsBuildTool
{
    public List<Project> GetProjects(DirectoryInfo directory)
    {
        var files = directory.EnumerateFiles("*.csproj", SearchOption.AllDirectories);
        var msBuildProjects = new List<Project>();

        foreach (var fileInfo in files)
        {
            try
            {
                Console.WriteLine(fileInfo.Name);
                var project = new Project(fileInfo.FullName);
                msBuildProjects.Add(project);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
            }
        }

        return msBuildProjects;
    }
}