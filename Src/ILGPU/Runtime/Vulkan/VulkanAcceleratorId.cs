using System;

namespace ILGPU.Runtime.Vulkan
{
    public class VulkanAcceleratorId : AcceleratorId
    {
        #region Instance

        /// <inheritdoc />
        public VulkanAcceleratorId(IntPtr physicalDevice) : base(AcceleratorType.Vulkan)
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the Vulkan device id.
        /// </summary>
        public uint DeviceId { get; private set; }

        #endregion

    }
}
