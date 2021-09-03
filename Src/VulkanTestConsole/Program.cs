using ILGPU.Runtime.Vulkan;
using System;

namespace VulkanTestConsole
{
    class Program
    {
        static unsafe void Main()
        {
            var api = VulkanAPI.CurrentAPI;
            var result = api.GetPhysicalDevices(out var arr);
            foreach (var device in arr)
            {
                var properties = api.GetPhysicalDeviceProperties(device);
                string name = properties.Name;
                Console.WriteLine(name);
            }
        }
    }
}
