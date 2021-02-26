using ILGPU.Tools.SourceGeneration.Nodes;
using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Text;

namespace ILGPU.Tools.SourceGeneration.Builders
{
    public abstract class SourceBuilder
    {
        public void Run()
        {
            var node = Generate();
            string ilgpuDir = Directory.GetParent(Environment.CurrentDirectory)
                ?.Parent?.Parent?.Parent?.FullName;

            if (ilgpuDir is null)
            {
                Console.Error.Write("ILGPU project directory not found.");
                return;
            }

            var inheritorType = this.GetType();
            var thisType = typeof(SourceBuilder);

            var className = inheritorType.Name;
            var namespaceName = inheritorType.Namespace;
            if (namespaceName is null)
            {
                Console.Error.Write("Could not find namespace for builder.");
                return;
            }

            var thisNamespaceName = thisType.Namespace;
            if (thisNamespaceName is null)
            {
                Console.Error.Write("Could not find namespace for abstract builder.");
                return;
            }

            // Trim Tools namespace
            if (namespaceName.StartsWith(thisNamespaceName))
            {
                var len = thisNamespaceName.Length;
                namespaceName = namespaceName[len..];
            }

            var namespaceAsPath =
                namespaceName.Replace(".", Path.DirectorySeparatorChar.ToString());

            var classAsFileName = className + ".Generated.cs";

            using var stream = File.Create(Path.Join(ilgpuDir, namespaceAsPath, classAsFileName));
            using var streamWriter = new StreamWriter(stream);
            using var writer = new IndentedTextWriter(streamWriter);
            node.WriteTo(writer);
        }

        public ParentNode Start()
        {
            return new();
        }

        public abstract Node Generate();
    }
}
