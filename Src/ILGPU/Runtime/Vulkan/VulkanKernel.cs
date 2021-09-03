using ILGPU.Backends.SPIRV;
using System.Reflection;

namespace ILGPU.Runtime.Vulkan
{
    public class VulkanKernel : Kernel
    {
        public VulkanKernel(
            VulkanAccelerator accelerator,
            SPIRVCompiledKernel compiledKernel,
            MethodInfo launcher) : base(accelerator, compiledKernel, launcher)
        { }

        protected override void DisposeAcceleratorObject(bool disposing) =>
            throw new System.NotImplementedException();
    }
}
