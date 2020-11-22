using System;
using System.IO;

namespace Frank.Apps.Zipper
{
    class Program
    {
        private static int _closingDelay = 10;

        static void Main(string[] args)
        {
            Console.WriteLine($"Arguments provided:\n{string.Join("\n", args)}");

            var identifier = new Identifier(args);

            if (!identifier.Arguments.ContainsKey(Argument.Filename))
            {
                Console.WriteLine("No filename! Ending...");
                return;
            }
            if (!identifier.Arguments.ContainsKey(Argument.Origin))
            {
                Console.WriteLine("No origin directory detected! Ending...");
                return;
            }
            if (!identifier.Arguments.ContainsKey(Argument.Destination))
            {
                identifier.Arguments.Add(Argument.Destination, Environment.CurrentDirectory);
            }

            var origin = new DirectoryInfo(identifier.Arguments[Argument.Origin]);
            var destination = new DirectoryInfo(identifier.Arguments[Argument.Destination]);
            var filename = identifier.Arguments[Argument.Filename];

            var zipper = new Zipper(origin, destination, filename);
            Console.WriteLine("Zipping");
            try
            {
                zipper.ZipIt();
                Console.WriteLine("Zip successful");
            }
            catch (Exception e)
            {
                Console.WriteLine("Zip failed!");
                Console.WriteLine($"Error: {e.Message}");
                Console.WriteLine($"Stacktrace:\n{e.StackTrace}");
                Console.WriteLine("Paused, hit enter, to close app...");
                Console.ReadLine();
                _closingDelay = 3;
            }
            finally
            {
                for (var a = _closingDelay; a >= 0; a--)
                {
                    Console.Write("\rClosing app in {0:00}", a);
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}
