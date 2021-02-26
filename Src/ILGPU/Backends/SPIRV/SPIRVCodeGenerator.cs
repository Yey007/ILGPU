using ILGPU.Backends.EntryPoints;
using ILGPU.IR.Analyses;
using System.Collections.Generic;

namespace ILGPU.Backends.SPIRV
{
    /// <summary>
    /// A SPIR-V code generator.
    /// </summary>
    public abstract partial class SPIRVCodeGenerator :
        SPIRVVariableAllocator, IBackendCodeGenerator<List<Word>>
    {
        #region Nested Types

        /// <summary>
        /// Generation arguments for code-generator construction.
        /// </summary>
        public readonly struct GeneratorArgs
        {
            internal GeneratorArgs(
                SPIRVBackend backend,
                EntryPoint entryPoint,
                SPRIVTypeGenerator generator,
                in AllocaKindInformation sharedAllocations,
                in AllocaKindInformation dynamicSharedAllocations)
            {
                Backend = backend;
                EntryPoint = entryPoint;
                TypeGenerator = generator;
                SharedAllocations = sharedAllocations;
                DynamicSharedAllocations = dynamicSharedAllocations;
            }

            /// <summary>
            /// Returns the underlying backend.
            /// </summary>
            public SPIRVBackend Backend { get; }

            /// <summary>
            /// Returns the type generator
            /// </summary>
            public SPRIVTypeGenerator TypeGenerator { get; }

            /// <summary>
            /// Returns the current entry point.
            /// </summary>
            public EntryPoint EntryPoint { get; }

            /// <summary>
            /// Returns all shared allocations.
            /// </summary>
            public AllocaKindInformation SharedAllocations { get; }

            /// <summary>
            /// Returns all dynamic shared allocations.
            /// </summary>
            public AllocaKindInformation DynamicSharedAllocations { get; }
        }

        #endregion

        #region Instance

        public List<Word> Builder { get; }

        /// <summary>
        /// Constructs a new code generator.
        /// </summary>
        /// <param name="args">The generator arguments.</param>
        internal SPIRVCodeGenerator(in GeneratorArgs args)
            : base(args.TypeGenerator)
        {
            Builder = new List<Word>();
        }

        #endregion

        #region IBackendCodeGenerator

        /// <summary>
        /// Generates a function declaration in SPIR-V code.
        /// </summary>
        public abstract void GenerateHeader(List<Word> builder);

        /// <summary>
        /// Generates SPIR-V code.
        /// </summary>
        public abstract void GenerateCode();

        /// <summary>
        /// Generates SPIR-V constant declarations.
        /// </summary>
        /// <param name="builder">The target builder.</param>
        public void GenerateConstants(List<Word> builder)
        {
            // No constants to emit
        }

        /// <summary cref="IBackendCodeGenerator{TKernelBuilder}.Merge(TKernelBuilder)"/>
        public void Merge(List<Word> builder) =>
            builder.AddRange(Builder);


        #endregion
    }
}
