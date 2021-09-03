using System;
using static ILGPU.Runtime.Vulkan.VulkanAPI;

namespace ILGPU.Runtime.Vulkan
{
    public sealed class VulkanAcceleratorId : AcceleratorId
    {
        #region Instance

        /// <inheritdoc />
        public VulkanAcceleratorId(IntPtr physicalDevice) : base(AcceleratorType.Vulkan)
        {
            PhysicalDevice = physicalDevice;

            var properties = CurrentAPI.GetPhysicalDeviceProperties(physicalDevice);
            DeviceType = properties.deviceType;
            DeviceId = properties.deviceID;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The physical device this AcceleratorId was created with.
        /// </summary>
        public IntPtr PhysicalDevice { get; }

        /// <summary>
        /// The Vulkan Device ID of this device.
        /// </summary>
        public uint DeviceId { get; }

        /// <summary>
        /// The type of the device.
        /// </summary>
        public VkPhysicalDeviceType DeviceType { get; }

        #endregion

    }
}
