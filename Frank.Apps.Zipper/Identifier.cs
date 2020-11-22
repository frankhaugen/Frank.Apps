using System.Collections.Generic;
using System.IO;

namespace Frank.Apps.Zipper
{
    public class Identifier
    {
        private List<string> _arguments;
        public Dictionary<Argument, string> Arguments { get; private set; }

        public Identifier(IEnumerable<string> arguments)
        {
            _arguments = new List<string>(arguments);
            Identify();
        }

        private void Identify()
        {
            Arguments = new Dictionary<Argument, string>();
            foreach (var argument in _arguments)
            {
                if (Path.HasExtension(argument) && !Arguments.ContainsKey(Argument.Filename))
                {
                    Arguments.Add(Argument.Filename, argument);
                    continue;
                }
                if (new DirectoryInfo(argument).Exists && !Arguments.ContainsKey(Argument.Origin))
                {
                    Arguments.Add(Argument.Origin, argument);
                    continue;
                }
                if (new DirectoryInfo(argument).Exists && !Arguments.ContainsKey(Argument.Destination))
                {
                    Arguments.Add(Argument.Destination, argument);
                }
            }
        }
    }
}
