using System;
using System.CodeDom.Compiler;

namespace ILGPU.Tools.SourceGeneration.Nodes
{
    public class NamespaceNode : Node
    {
        private string _name;

        public NamespaceNode Name(string name)
        {
            _name = name;
            return this;
        }

        public NamespaceNode Type(Func<TypeNode, TypeNode> typeOptions)
        {
            var t = new TypeNode();
            t = typeOptions(t);
            AddChild(t);
            return this;
        }

        public override void WriteTo(IndentedTextWriter writer)
        {
            writer.WriteLine($"namespace {_name} {{");
            writer.Indent += standardIndent;
            Children.ForEach(c => c.WriteTo(writer));
            writer.Indent -= standardIndent;
            writer.WriteLine("}");
        }
    }
}
