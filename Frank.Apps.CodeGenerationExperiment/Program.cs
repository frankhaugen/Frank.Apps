using System;
using System.IO;

namespace Frank.Apps.CodeGenerationExperiment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //var example = new RoslyQuoterExample();
            var example = new CodeGenExample();

            var className = "FluentCalculator";

            var result = example.ExecuteReal("Frank.Libraries.Calculators.FluentCalculation", className);

            var directoryPath = Path.Combine("C:", "repos", "frankhaugen", "Frank.Libraries", "Frank.Libraries.Calculators", "FluentCalculation");

            var filePath = Path.Combine(directoryPath, className + ".cs");

            File.WriteAllText(filePath, result);

            Console.WriteLine(result);

        }
    }
}
