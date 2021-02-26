using ILGPU.IR.Types;
using ILGPU.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ILGPU.Backends.SPIRV
{
    /// <summary>
    /// A SPIR-V type generator
    /// </summary>
    public class SPRIVTypeGenerator
    {
        private readonly Dictionary<TypeNode, uint> nodeToIdMapping =
            new Dictionary<TypeNode, uint>();

        /// <summary>
        /// Generates or gets a SPIR-V type definition for a node
        /// </summary>
        /// <param name="typeNode">The type node to generate the definition for</param>
        /// <param name="currentIdhe last word id used</param>
        /// <param name="currentId">The next word id that should be used</param>
        /// <returns>The type definition</returns>
        /// <remarks>
        /// This will generate THE ENTIRE DEFINITION, including assignment to and id etc.
        /// </remarks>
        public List<Word> GetOrGenerateTypeDefinition(TypeNode typeNode, uint currentId, out uint nextId)
        {
            Debug.Assert(!(typeNode is ViewType), "Invalid view type");

            nextId = currentId;

            if (nodeToIdMapping.TryGetValue(typeNode, out uint id))
            {
                return new List<Word>
                {
                    new Word(id)
                };
            }


            switch (typeNode)
            {
                case VoidType v:
                    return GenerateVoidType(v, currentId, out nextId);
                case PrimitiveType p:
                    return GeneratePrimitiveType(p, currentId, out nextId);
                default:
                    throw new InvalidCodeGenerationException();
            }
        }

        private List<Word> GenerateVoidType(VoidType typeNode, uint currentId, out uint nextId)
        {
            nextId = currentId + 1;
            nodeToIdMapping[typeNode] = currentId;
            return new List<Word>
            {
                new Word(new SplitWord(2, SPIRVHeaders.Op.OpTypeVoid)),
                new Word(currentId)
            };
        }

        private List<Word> GeneratePrimitiveType(PrimitiveType typeNode, uint currentId, out uint nextId)
        {
            nextId = currentId + 1;
            var list = new List<Word>();

            if (typeNode.BasicValueType.IsInt())
            {
                switch (typeNode.BasicValueType)
                {
                    case BasicValueType.Int1:
                        list.Add(new Word(new SplitWord(4, SPIRVHeaders.Op.OpTypeInt)));
                        list.Add(new Word(1));
                        list.Add(new Word(1));
                        break;
                    case BasicValueType.Int8:
                        break;
                    case BasicValueType.Int16:
                        break;
                    case BasicValueType.Int32:
                        break;
                    case BasicValueType.Int64:
                        break;
                }
            }
            else if (typeNode.BasicValueType.IsFloat())
            {
                switch (typeNode.BasicValueType)
                {
                    case BasicValueType.Float16:
                        break;
                    case BasicValueType.Float32:
                        break;
                    case BasicValueType.Float64:
                        break;
                }
            }
            else
            {
                //TODO: How to handle None?
                throw new NotImplementedException();
            }

            return list;
        }
    }
}
