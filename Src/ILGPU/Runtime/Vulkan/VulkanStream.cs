using static ILGPU.Runtime.Vulkan.VulkanAPI;

namespace ILGPU.Runtime.Vulkan
{
    public class VulkanStream : AcceleratorStream
    {
        public VulkanStream(VulkanAccelerator accelerator) : base(accelerator)
        {



        }

        protected override void DisposeAcceleratorObject(bool disposing) => throw new System.NotImplementedException();

        public override void Synchronize() => throw new System.NotImplementedException();
    }
}
