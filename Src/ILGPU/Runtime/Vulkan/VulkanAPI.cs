using System;
using System.Text;

namespace ILGPU.Runtime.Vulkan
{
    public unsafe partial class VulkanAPI
    {
        private IntPtr instance;

        /// <inheritdoc />
        public override bool Init()
        {
            VkInstanceCreateInfo info = VkInstanceCreateInfo.New();
            VkResult result = vkCreateInstance(ref info, IntPtr.Zero, out instance);
            if (result != VkResult.VK_SUCCESS)
            {
                return false;
            }

            result = GetNumPhysicalDevices(out uint numDevices);
            return result == VkResult.VK_SUCCESS && numDevices >= 1;
        }

        /// <summary>
        /// Gets the number of physical devices.
        /// </summary>
        /// <param name="numDevices">The output number.</param>
        /// <returns>The result of the operation.</returns>
        public VkResult GetNumPhysicalDevices(out uint numDevices)
        {
            numDevices = 0;
            return vkEnumeratePhysicalDevices(instance, ref numDevices, null);
        }


        /// <summary>
        /// Gets all physical device handles.
        /// </summary>
        /// <param name="devices">The devices.</param>
        /// <returns>The result of the operation.</returns>
        public VkResult GetPhysicalDevices(out IntPtr[] devices)
        {
            var result = GetNumPhysicalDevices(out uint numDevices);
            devices = new IntPtr[numDevices];
            if (result != VkResult.VK_SUCCESS)
            {
                return result;
            }

            fixed (IntPtr* ptr = &devices[0])
            {
                return vkEnumeratePhysicalDevices(instance, ref numDevices, ptr);
            }
        }

        /// <summary>
        /// Gets properties for a given physical device.
        /// </summary>
        /// <param name="device">The device.</param>
        /// <returns>The properties of the device.</returns>
        public VkPhysicalDeviceProperties GetPhysicalDeviceProperties(IntPtr device)
        {
            var properties = new VkPhysicalDeviceProperties();
            vkGetPhysicalDeviceProperties(device, &properties);
            return properties;
        }
    }
}
