using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;

namespace ILGPU.Tools.SourceGeneration.Nodes
{
    public class TypeNode : Node
    {
        private string _name;
        private HashSet<TypeModifiers> TypeModifiers { get; } = new();

        public override void WriteTo(IndentedTextWriter writer)
        {
            var orderedList = TypeModifiers.OrderBy(t => (int)t);
            var asStringList = orderedList.Select(t => t.ToUsableString());

            writer.Write(string.Join(' ', asStringList));

            writer.WriteLine($" {_name} {{");

            writer.Indent += standardIndent;
            Children.ForEach(c => c.WriteTo(writer));
            writer.Indent -= standardIndent;

            writer.WriteLine("}");
        }

        public TypeNode Name(string name)
        {
            _name = name;
            return this;
        }

        public TypeNode TypeModifier(TypeModifiers t)
        {
            TypeModifiers.Add(t);
            return this;
        }
    }
}
