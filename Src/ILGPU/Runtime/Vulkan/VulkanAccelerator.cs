using ILGPU.Backends.SPIRV;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Text;
using static ILGPU.Runtime.Vulkan.VulkanAPI;

namespace ILGPU.Runtime.Vulkan
{
    public class VulkanAccelerator : KernelAccelerator<SPIRVCompiledKernel, VulkanKernel>
    {
        #region Instance

        static VulkanAccelerator()
        {
            CurrentAPI.GetPhysicalDevices(out IntPtr[] devices);
            VulkanAccelerators = devices.Select(x => new VulkanAcceleratorId(x))
                .ToImmutableArray();
        }

        public VulkanAccelerator(Context context, VulkanAcceleratorId acceleratorId) :
            base(context, AcceleratorType.Vulkan)
        {
            if (acceleratorId == null)
                throw new ArgumentNullException(nameof(acceleratorId));

            Backends.Backend.EnsureRunningOnNativePlatform();

            SetupAccelerator(acceleratorId);
        }

        #endregion

        #region Properties

        public static ImmutableArray<VulkanAcceleratorId> VulkanAccelerators { get; }

        #endregion

        #region Methods

        private void SetupAccelerator(VulkanAcceleratorId id)
        {
            Bind();

            var properties = CurrentAPI.GetPhysicalDeviceProperties(id.PhysicalDevice);

            Name = properties.Name;
            DefaultStream = new VulkanStream(this);
        }

        protected override bool CanAccessPeerInternal(Accelerator otherAccelerator) =>
            throw new NotImplementedException();

        protected override void EnablePeerAccessInternal(Accelerator otherAccelerator) =>
            throw new NotImplementedException();

        protected override void DisablePeerAccessInternal(Accelerator otherAccelerator) =>
            throw new NotImplementedException();

        protected override void OnBind() =>
            throw new NotImplementedException();

        protected override void OnUnbind() =>
            throw new NotImplementedException();

        public override TExtension
            CreateExtension<TExtension, TExtensionProvider>(
                TExtensionProvider provider) => throw new NotImplementedException();

        protected override MemoryBuffer<T, TIndex>
            AllocateInternal<T, TIndex>(TIndex extent) =>
            throw new NotImplementedException();

        protected override AcceleratorStream CreateStreamInternal() =>
            throw new NotImplementedException();

        protected override void SynchronizeInternal() =>
            throw new NotImplementedException();

        protected override int EstimateMaxActiveGroupsPerMultiprocessorInternal(
            Kernel kernel, int groupSize,
            int dynamicSharedMemorySizeInBytes) =>
            throw new NotImplementedException();

        protected override int EstimateGroupSizeInternal(Kernel kernel,
            Func<int, int> computeSharedMemorySize,
            int maxGroupSize, out int minGridSize) =>
            throw new NotImplementedException();

        protected override int EstimateGroupSizeInternal(Kernel kernel,
            int dynamicSharedMemorySizeInBytes,
            int maxGroupSize, out int minGridSize) =>
            throw new NotImplementedException();

        protected override void DisposeAccelerator_SyncRoot(bool disposing) =>
            throw new NotImplementedException();

        protected override MethodInfo GenerateKernelLauncherMethod(
            SPIRVCompiledKernel kernel, int customGroupSize) =>
            throw new NotImplementedException();

        protected override VulkanKernel
            CreateKernel(SPIRVCompiledKernel compiledKernel) =>
            throw new NotImplementedException();

        protected override VulkanKernel CreateKernel(SPIRVCompiledKernel compiledKernel,
            MethodInfo launcher) => throw new NotImplementedException();

        #endregion

    }
}
