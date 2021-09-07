using System;

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
        /// <param name="physicalDevices">The devices.</param>
        /// <returns>The result of the operation.</returns>
        public VkResult GetPhysicalDevices(out IntPtr[] physicalDevices)
        {
            var result = GetNumPhysicalDevices(out uint numDevices);
            physicalDevices = new IntPtr[numDevices];
            if (result != VkResult.VK_SUCCESS)
            {
                return result;
            }

            fixed (IntPtr* ptr = &physicalDevices[0])
            {
                return vkEnumeratePhysicalDevices(instance, ref numDevices, ptr);
            }
        }

        /// <summary>
        /// Gets properties for a given physical device.
        /// </summary>
        /// <param name="physicalDevice">The device.</param>
        /// <returns>The properties of the device.</returns>
        public VkPhysicalDeviceProperties GetPhysicalDeviceProperties(
            IntPtr physicalDevice)
        {
            var properties = new VkPhysicalDeviceProperties();
            vkGetPhysicalDeviceProperties(physicalDevice, ref properties);
            return properties;
        }

        public IntPtr CreateLogicalDevice(IntPtr physicalDevice)
        {
            var propertiesArray =
                CurrentAPI.GetPhysicalDeviceQueueProperties(physicalDevice);

            int queueFamilyIndex = Array.FindIndex(propertiesArray,
                x => x.queueFlags.HasFlag(VkQueueFlags.VK_QUEUE_COMPUTE_BIT));


        }

        /// <summary>
        /// Creates a Vulkan queue.
        /// </summary>
        /// <param name="logicalDevice">
        /// The device associated with the queue
        /// </param>
        /// <param name="queueFamilyIndex">
        /// The index into the queue family properties array to use
        /// </param>
        public IntPtr GetQueue(IntPtr logicalDevice, uint queueFamilyIndex)
        {
            vkGetDeviceQueue(logicalDevice, queueFamilyIndex, 0, out var queue);
            return queue;
        }

        // var propertiesArray =
        //     CurrentAPI.GetPhysicalDeviceQueueProperties(logicalDevice);
        //
        // int queueFamilyIndex = Array.FindIndex(propertiesArray,
        //     x => x.queueFlags.HasFlag(VkQueueFlags.VK_QUEUE_COMPUTE_BIT));

        /// <summary>
        /// Gets queue properties for a given physical device.
        /// </summary>
        /// <param name="physicalDevice">The physical device.</param>
        /// <returns>The properties of the device.</returns>
        public VkQueueFamilyProperties[] GetPhysicalDeviceQueueProperties(
            IntPtr physicalDevice)
        {
            uint numQueueFamily = 0;
            vkGetPhysicalDeviceQueueFamilyProperties(physicalDevice, ref numQueueFamily,
                null);

            var properties = new VkQueueFamilyProperties[numQueueFamily];

            fixed (VkQueueFamilyProperties* ptr = &properties[0])
            {
                vkGetPhysicalDeviceQueueFamilyProperties(physicalDevice,
                    ref numQueueFamily, ptr);
            }

            return properties;
        }
    }
}
