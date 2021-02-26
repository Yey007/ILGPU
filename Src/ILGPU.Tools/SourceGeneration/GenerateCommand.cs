using ILGPU.Tools.SourceGeneration.Builders;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ILGPU.Tools.SourceGeneration
{
    public class GenerateCommand : ICommand
    {
        public List<SourceBuilder> Builders = new();

        public GenerateCommand()
        {
            var asm = Assembly.GetAssembly(typeof(GenerateCommand));
            if (asm is null)
            {
                Console.Error.WriteLine("Unable to load assemblies.");
                return;
            }

            foreach (var t in asm.GetExportedTypes())
            {
                if(t.BaseType is null)
                    continue;

                if(t.BaseType != typeof(SourceBuilder))
                    continue;

                // Skip if abstract
                if ((t.Attributes & TypeAttributes.Abstract) == TypeAttributes.Abstract)
                    continue;

                Builders.Add((SourceBuilder) Activator.CreateInstance(t));
            }
        }

        public void Run(string[] args)
        {
            if (args[0] == "all")
            {
                foreach (var builder in Builders)
                {
                    builder.Run();
                }
            }
        }
    }
}
