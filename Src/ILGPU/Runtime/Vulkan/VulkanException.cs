using System.Runtime.CompilerServices;

namespace ILGPU.Runtime.Vulkan
{
    public class VulkanException : AcceleratorException
    {
        public VulkanException(VkResult result)
            : base("The result of a Vulkan operation " +
                   $"was not VK_SUCCESS, it was {result}")
        {
        }

        /// <inheritdoc />
        public override AcceleratorType AcceleratorType { get; } = AcceleratorType.Vulkan;

        /// <summary>
        /// Checks the given result and throws an exception in case of an error.
        /// </summary>
        /// <param name="result">The Vulkan status to check.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfFailed(VkResult result)
        {
            if (result != VkResult.VK_SUCCESS)
                throw new VulkanException(result);
        }
    }
}
