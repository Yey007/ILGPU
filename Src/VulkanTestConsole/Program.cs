using ILGPU.Runtime.Vulkan;
using System;
using System.Text;

namespace VulkanTestConsole
{
    class Program
    {
        static void Main()
        {
            var api = VulkanAPI.CurrentAPI;
            var result = api.GetPhysicalDevices(out var arr);
            foreach (var device in arr)
            {
                var properties = api.GetPhysicalDeviceProperties(device);

            }
        }
    }
}
