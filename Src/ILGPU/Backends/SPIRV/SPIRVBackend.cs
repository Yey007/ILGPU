using ILGPU.Backends.EntryPoints;
using ILGPU.IR;
using ILGPU.IR.Analyses;
using ILGPU.Runtime;
using System;
using System.Collections.Generic;

namespace ILGPU.Backends.SPIRV
{
    public class SPIRVBackend : CodeGeneratorBackend<
        SPIRVIntrinsic.Handler,
        SPIRVCodeGenerator.GeneratorArgs,
        SPIRVCodeGenerator,
        List<Word>>
    {
        public SPIRVBackend(
            Context context,
            CapabilityContext capabilities,
            BackendType backendType,
            BackendFlags backendFlags,
            ArgumentMapper argumentMapper) :
            base(context,
                capabilities,
                backendType,
                backendFlags,
                argumentMapper)
        {
        }

        protected override List<Word> CreateKernelBuilder(
            EntryPoint entryPoint,
            in BackendContext backendContext,
            in KernelSpecialization specialization,
            out SPIRVCodeGenerator.GeneratorArgs data)
        {
            backendContext.EnsureIntrinsicImplementations(IntrinsicProvider);

            var builder = new List<Word>();

            data = new SPIRVCodeGenerator.GeneratorArgs(
                this,
                entryPoint,
                new SPRIVTypeGenerator(),
                backendContext.SharedAllocations,
                backendContext.DynamicSharedAllocations);
            return builder;
        }

        protected override SPIRVCodeGenerator CreateFunctionCodeGenerator(
            Method method,
            Allocas allocas,
            SPIRVCodeGenerator.GeneratorArgs data) =>
            throw new NotImplementedException();

        protected override SPIRVCodeGenerator CreateKernelCodeGenerator(
            in AllocaKindInformation sharedAllocations,
            Method method,
            Allocas allocas,
            SPIRVCodeGenerator.GeneratorArgs data) => throw new NotImplementedException();

        protected override CompiledKernel CreateKernel(EntryPoint entryPoint,
            CompiledKernel.KernelInfo kernelInfo,
            List<Word> builder, SPIRVCodeGenerator.GeneratorArgs data) =>
            throw new NotImplementedException();
    }
}
