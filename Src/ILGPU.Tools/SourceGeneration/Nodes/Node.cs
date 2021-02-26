using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace ILGPU.Tools.SourceGeneration.Nodes
{
    public abstract class Node
    {
        protected List<Node> Children { get; } = new();

        protected const int standardIndent = 1;

        public abstract void WriteTo(IndentedTextWriter writer);

        protected Node AddChild(Node node)
        {
            Children.Add(node);
            return this;
        }
    }
}
