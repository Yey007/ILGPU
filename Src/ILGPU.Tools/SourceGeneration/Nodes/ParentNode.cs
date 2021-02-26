using System;
using System.CodeDom.Compiler;

namespace ILGPU.Tools.SourceGeneration.Nodes
{
    public class ParentNode : Node
    {
        public ParentNode Namespace(Func<NamespaceNode, NamespaceNode> namespaceOptions)
        {
            var n = new NamespaceNode();
            n = namespaceOptions(n);
            AddChild(n);
            return this;
        }

        public override void WriteTo(IndentedTextWriter writer)
        {
            Children.ForEach(c => c.WriteTo(writer));
        }
    }
}
