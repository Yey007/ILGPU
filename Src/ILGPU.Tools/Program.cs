using ILGPU.Tools.SourceGeneration;
using System;
using System.Collections.Generic;

namespace ILGPU.Tools
{
    class Program
    {
        private static readonly Dictionary<string, ICommand> commands = new()
        {
            {"generate", new GenerateCommand()}
        };

        static void Main(string[] args)
        {
            if (!commands.TryGetValue(args[0], out var command))
            {
                Console.Error.WriteLine("Unknown command.");
                return;
            }

            command.Run(args[1..]);
        }
    }
}
