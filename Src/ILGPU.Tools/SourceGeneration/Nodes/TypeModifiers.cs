using System.ComponentModel;

namespace ILGPU.Tools.SourceGeneration.Nodes
{
    public enum TypeModifiers
    {
        Public,
        Protected,
        Private,

        Class,
        Struct,
        Interface,
        Enum
    }

    internal static class TypeModifiersExtensions
    {
        public static string ToUsableString(this TypeModifiers m)
        {
            return m.ToString().ToLower();
        }
    }
}
