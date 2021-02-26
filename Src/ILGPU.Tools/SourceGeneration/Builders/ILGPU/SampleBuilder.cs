using ILGPU.Tools.SourceGeneration.Nodes;

namespace ILGPU.Tools.SourceGeneration.Builders.ILGPU
{
    public class SampleBuilder : SourceBuilder
    {
        public override Node Generate()
        {
            return Start().Namespace(n => n.Name("ILGPU")
                .Type(t => t
                    .Name("MyClass")
                    .TypeModifier(TypeModifiers.Public)
                    .TypeModifier(TypeModifiers.Class)
                ));
        }
    }
}
