using System;
using System.Runtime.InteropServices;

namespace ILGPU.Runtime.Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    unsafe struct VkApplicationInfo
    {
        VkStructureType sType;
        void* pNext;
        byte* pApplicationName; // byte* to match c++ 8-bit chars
        uint applicationVersion;
        byte* pEngineName;
        uint engineVersion;
        uint apiVersion;

        // Structs can't have explicit 0-parameter constructors
        public static VkApplicationInfo New() =>
            new VkApplicationInfo
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_APPLICATION_INFO
            };
    };

    [StructLayout(LayoutKind.Sequential)]
    unsafe struct VkInstanceCreateInfo
    {
        VkStructureType sType;
        void* pNext;
        VkInstanceCreateFlags flags;
        VkApplicationInfo* pApplicationInfo;
        uint enabledLayerCount;
        byte** ppEnabledLayerNames;
        uint enabledExtensionCount;
        byte** ppEnabledExtensionNames;

        public static VkInstanceCreateInfo New() =>
            new VkInstanceCreateInfo
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO
            };
    }

    // Reserved for future use
    enum VkInstanceCreateFlags
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct VkPhysicalDeviceProperties
    {
        uint apiVersion;
        uint driverVersion;
        uint vendorID;
        uint deviceID;
        VkPhysicalDeviceType deviceType;
        public fixed byte deviceName[256];
        fixed byte pipelineCacheUUID[16];
        VkPhysicalDeviceLimits limits;
        VkPhysicalDeviceSparseProperties sparseProperties;
    };

    enum VkPhysicalDeviceType
    {
        VK_PHYSICAL_DEVICE_TYPE_OTHER = 0,
        VK_PHYSICAL_DEVICE_TYPE_INTEGRATED_GPU = 1,
        VK_PHYSICAL_DEVICE_TYPE_DISCRETE_GPU = 2,
        VK_PHYSICAL_DEVICE_TYPE_VIRTUAL_GPU = 3,
        VK_PHYSICAL_DEVICE_TYPE_CPU = 4,
    };

    [StructLayout(LayoutKind.Sequential)]
    unsafe struct VkPhysicalDeviceLimits
    {
        uint maxImageDimension1D;
        uint maxImageDimension2D;
        uint maxImageDimension3D;
        uint maxImageDimensionCube;
        uint maxImageArrayLayers;
        uint maxTexelBufferElements;
        uint maxUniformBufferRange;
        uint maxStorageBufferRange;
        uint maxPushConstantsSize;
        uint maxMemoryAllocationCount;
        uint maxSamplerAllocationCount;
        ulong bufferImageGranularity;
        ulong sparseAddressSpaceSize;
        uint maxBoundDescriptorSets;
        uint maxPerStageDescriptorSamplers;
        uint maxPerStageDescriptorUniformBuffers;
        uint maxPerStageDescriptorStorageBuffers;
        uint maxPerStageDescriptorSampledImages;
        uint maxPerStageDescriptorStorageImages;
        uint maxPerStageDescriptorInputAttachments;
        uint maxPerStageResources;
        uint maxDescriptorSetSamplers;
        uint maxDescriptorSetUniformBuffers;
        uint maxDescriptorSetUniformBuffersDynamic;
        uint maxDescriptorSetStorageBuffers;
        uint maxDescriptorSetStorageBuffersDynamic;
        uint maxDescriptorSetSampledImages;
        uint maxDescriptorSetStorageImages;
        uint maxDescriptorSetInputAttachments;
        uint maxVertexInputAttributes;
        uint maxVertexInputBindings;
        uint maxVertexInputAttributeOffset;
        uint maxVertexInputBindingStride;
        uint maxVertexOutputComponents;
        uint maxTessellationGenerationLevel;
        uint maxTessellationPatchSize;
        uint maxTessellationControlPerVertexInputComponents;
        uint maxTessellationControlPerVertexOutputComponents;
        uint maxTessellationControlPerPatchOutputComponents;
        uint maxTessellationControlTotalOutputComponents;
        uint maxTessellationEvaluationInputComponents;
        uint maxTessellationEvaluationOutputComponents;
        uint maxGeometryShaderInvocations;
        uint maxGeometryInputComponents;
        uint maxGeometryOutputComponents;
        uint maxGeometryOutputVertices;
        uint maxGeometryTotalOutputComponents;
        uint maxFragmentInputComponents;
        uint maxFragmentOutputAttachments;
        uint maxFragmentDualSrcAttachments;
        uint maxFragmentCombinedOutputResources;
        uint maxComputeSharedMemorySize;
        fixed uint maxComputeWorkGroupCount[3];
        uint maxComputeWorkGroupInvocations;
        fixed uint maxComputeWorkGroupSize[3];
        uint subPixelPrecisionBits;
        uint subTexelPrecisionBits;
        uint mipmapPrecisionBits;
        uint maxDrawIndexedIndexValue;
        uint maxDrawIndirectCount;
        float maxSamplerLodBias;
        float maxSamplerAnisotropy;
        uint maxViewports;
        fixed uint maxViewportDimensions[2];
        fixed float viewportBoundsRange[2];
        uint viewportSubPixelBits;
        UIntPtr minMemoryMapAlignment;
        ulong minTexelBufferOffsetAlignment;
        ulong minUniformBufferOffsetAlignment;
        ulong minStorageBufferOffsetAlignment;
        int minTexelOffset;
        uint maxTexelOffset;
        int minTexelGatherOffset;
        uint maxTexelGatherOffset;
        float minInterpolationOffset;
        float maxInterpolationOffset;
        uint subPixelInterpolationOffsetBits;
        uint maxFramebufferWidth;
        uint maxFramebufferHeight;
        uint maxFramebufferLayers;
        uint framebufferColorSampleCounts;
        uint framebufferDepthSampleCounts;
        uint framebufferStencilSampleCounts;
        uint framebufferNoAttachmentsSampleCounts;
        uint maxColorAttachments;
        uint sampledImageColorSampleCounts;
        uint sampledImageIntegerSampleCounts;
        uint sampledImageDepthSampleCounts;
        uint sampledImageStencilSampleCounts;
        uint storageImageSampleCounts;
        uint maxSampleMaskWords;
        uint timestampComputeAndGraphics;
        float timestampPeriod;
        uint maxClipDistances;
        uint maxCullDistances;
        uint maxCombinedClipAndCullDistances;
        uint discreteQueuePriorities;
        fixed float pointSizeRange[2];
        fixed float lineWidthRange[2];
        float pointSizeGranularity;
        float lineWidthGranularity;
        uint strictLines;
        uint standardSampleLocations;
        ulong optimalBufferCopyOffsetAlignment;
        ulong optimalBufferCopyRowPitchAlignment;
        ulong nonCoherentAtomSize;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct VkPhysicalDeviceSparseProperties
    {
        uint residencyStandard2DBlockShape;
        uint residencyStandard2DMultisampleBlockShape;
        uint residencyStandard3DBlockShape;
        uint residencyAlignedMipSize;
        uint residencyNonResidentStrict;
    };

    enum VkStructureType
    {
        VK_STRUCTURE_TYPE_APPLICATION_INFO = 0,
        VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO = 1,
        VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO = 2,
        VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO = 3,
        VK_STRUCTURE_TYPE_SUBMIT_INFO = 4,
        VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_INFO = 5,
        VK_STRUCTURE_TYPE_MAPPED_MEMORY_RANGE = 6,
        VK_STRUCTURE_TYPE_BIND_SPARSE_INFO = 7,
        VK_STRUCTURE_TYPE_FENCE_CREATE_INFO = 8,
        VK_STRUCTURE_TYPE_SEMAPHORE_CREATE_INFO = 9,
        VK_STRUCTURE_TYPE_EVENT_CREATE_INFO = 10,
        VK_STRUCTURE_TYPE_QUERY_POOL_CREATE_INFO = 11,
        VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO = 12,
        VK_STRUCTURE_TYPE_BUFFER_VIEW_CREATE_INFO = 13,
        VK_STRUCTURE_TYPE_IMAGE_CREATE_INFO = 14,
        VK_STRUCTURE_TYPE_IMAGE_VIEW_CREATE_INFO = 15,
        VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO = 16,
        VK_STRUCTURE_TYPE_PIPELINE_CACHE_CREATE_INFO = 17,
        VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO = 18,
        VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_STATE_CREATE_INFO = 19,
        VK_STRUCTURE_TYPE_PIPELINE_INPUT_ASSEMBLY_STATE_CREATE_INFO = 20,
        VK_STRUCTURE_TYPE_PIPELINE_TESSELLATION_STATE_CREATE_INFO = 21,
        VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_STATE_CREATE_INFO = 22,
        VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_CREATE_INFO = 23,
        VK_STRUCTURE_TYPE_PIPELINE_MULTISAMPLE_STATE_CREATE_INFO = 24,
        VK_STRUCTURE_TYPE_PIPELINE_DEPTH_STENCIL_STATE_CREATE_INFO = 25,
        VK_STRUCTURE_TYPE_PIPELINE_COLOR_BLEND_STATE_CREATE_INFO = 26,
        VK_STRUCTURE_TYPE_PIPELINE_DYNAMIC_STATE_CREATE_INFO = 27,
        VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_CREATE_INFO = 28,
        VK_STRUCTURE_TYPE_COMPUTE_PIPELINE_CREATE_INFO = 29,
        VK_STRUCTURE_TYPE_PIPELINE_LAYOUT_CREATE_INFO = 30,
        VK_STRUCTURE_TYPE_SAMPLER_CREATE_INFO = 31,
        VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_CREATE_INFO = 32,
        VK_STRUCTURE_TYPE_DESCRIPTOR_POOL_CREATE_INFO = 33,
        VK_STRUCTURE_TYPE_DESCRIPTOR_SET_ALLOCATE_INFO = 34,
        VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET = 35,
        VK_STRUCTURE_TYPE_COPY_DESCRIPTOR_SET = 36,
        VK_STRUCTURE_TYPE_FRAMEBUFFER_CREATE_INFO = 37,
        VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO = 38,
        VK_STRUCTURE_TYPE_COMMAND_POOL_CREATE_INFO = 39,
        VK_STRUCTURE_TYPE_COMMAND_BUFFER_ALLOCATE_INFO = 40,
        VK_STRUCTURE_TYPE_COMMAND_BUFFER_INHERITANCE_INFO = 41,
        VK_STRUCTURE_TYPE_COMMAND_BUFFER_BEGIN_INFO = 42,
        VK_STRUCTURE_TYPE_RENDER_PASS_BEGIN_INFO = 43,
        VK_STRUCTURE_TYPE_BUFFER_MEMORY_BARRIER = 44,
        VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER = 45,
        VK_STRUCTURE_TYPE_MEMORY_BARRIER = 46,
        VK_STRUCTURE_TYPE_LOADER_INSTANCE_CREATE_INFO = 47,
        VK_STRUCTURE_TYPE_LOADER_DEVICE_CREATE_INFO = 48,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SUBGROUP_PROPERTIES = 1000094000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_BIND_BUFFER_MEMORY_INFO = 1000157000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_INFO = 1000157001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_16BIT_STORAGE_FEATURES = 1000083000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_MEMORY_DEDICATED_REQUIREMENTS = 1000127000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_MEMORY_DEDICATED_ALLOCATE_INFO = 1000127001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_FLAGS_INFO = 1000060000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_DEVICE_GROUP_RENDER_PASS_BEGIN_INFO = 1000060003,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_DEVICE_GROUP_COMMAND_BUFFER_BEGIN_INFO = 1000060004,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_DEVICE_GROUP_SUBMIT_INFO = 1000060005,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_DEVICE_GROUP_BIND_SPARSE_INFO = 1000060006,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_BIND_BUFFER_MEMORY_DEVICE_GROUP_INFO = 1000060013,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_DEVICE_GROUP_INFO = 1000060014,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_GROUP_PROPERTIES = 1000070000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_DEVICE_GROUP_DEVICE_CREATE_INFO = 1000070001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_BUFFER_MEMORY_REQUIREMENTS_INFO_2 = 1000146000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_IMAGE_MEMORY_REQUIREMENTS_INFO_2 = 1000146001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_IMAGE_SPARSE_MEMORY_REQUIREMENTS_INFO_2 = 1000146002,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_MEMORY_REQUIREMENTS_2 = 1000146003,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_SPARSE_IMAGE_MEMORY_REQUIREMENTS_2 = 1000146004,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FEATURES_2 = 1000059000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROPERTIES_2 = 1000059001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_FORMAT_PROPERTIES_2 = 1000059002,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_IMAGE_FORMAT_PROPERTIES_2 = 1000059003,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_FORMAT_INFO_2 = 1000059004,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_QUEUE_FAMILY_PROPERTIES_2 = 1000059005,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MEMORY_PROPERTIES_2 = 1000059006,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_SPARSE_IMAGE_FORMAT_PROPERTIES_2 = 1000059007,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SPARSE_IMAGE_FORMAT_INFO_2 = 1000059008,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_POINT_CLIPPING_PROPERTIES = 1000117000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_RENDER_PASS_INPUT_ATTACHMENT_ASPECT_CREATE_INFO = 1000117001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_IMAGE_VIEW_USAGE_CREATE_INFO = 1000117002,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PIPELINE_TESSELLATION_DOMAIN_ORIGIN_STATE_CREATE_INFO =
            1000117003,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_RENDER_PASS_MULTIVIEW_CREATE_INFO = 1000053000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_FEATURES = 1000053001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_PROPERTIES = 1000053002,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTERS_FEATURES = 1000120000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PROTECTED_SUBMIT_INFO = 1000145000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROTECTED_MEMORY_FEATURES = 1000145001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROTECTED_MEMORY_PROPERTIES = 1000145002,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_DEVICE_QUEUE_INFO_2 = 1000145003,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_CREATE_INFO = 1000156000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_INFO = 1000156001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_BIND_IMAGE_PLANE_MEMORY_INFO = 1000156002,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_IMAGE_PLANE_MEMORY_REQUIREMENTS_INFO = 1000156003,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLER_YCBCR_CONVERSION_FEATURES = 1000156004,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_IMAGE_FORMAT_PROPERTIES = 1000156005,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_DESCRIPTOR_UPDATE_TEMPLATE_CREATE_INFO = 1000085000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_IMAGE_FORMAT_INFO = 1000071000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXTERNAL_IMAGE_FORMAT_PROPERTIES = 1000071001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_BUFFER_INFO = 1000071002,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXTERNAL_BUFFER_PROPERTIES = 1000071003,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ID_PROPERTIES = 1000071004,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_BUFFER_CREATE_INFO = 1000072000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_IMAGE_CREATE_INFO = 1000072001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXPORT_MEMORY_ALLOCATE_INFO = 1000072002,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_FENCE_INFO = 1000112000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXTERNAL_FENCE_PROPERTIES = 1000112001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXPORT_FENCE_CREATE_INFO = 1000113000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXPORT_SEMAPHORE_CREATE_INFO = 1000077000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_SEMAPHORE_INFO = 1000076000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXTERNAL_SEMAPHORE_PROPERTIES = 1000076001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_3_PROPERTIES = 1000168000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_SUPPORT = 1000168001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_DRAW_PARAMETERS_FEATURES = 1000063000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_1_FEATURES = 49,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_1_PROPERTIES = 50,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_2_FEATURES = 51,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_2_PROPERTIES = 52,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_IMAGE_FORMAT_LIST_CREATE_INFO = 1000147000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_ATTACHMENT_DESCRIPTION_2 = 1000109000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_ATTACHMENT_REFERENCE_2 = 1000109001,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SUBPASS_DESCRIPTION_2 = 1000109002,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SUBPASS_DEPENDENCY_2 = 1000109003,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO_2 = 1000109004,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SUBPASS_BEGIN_INFO = 1000109005,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SUBPASS_END_INFO = 1000109006,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_8BIT_STORAGE_FEATURES = 1000177000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DRIVER_PROPERTIES = 1000196000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_ATOMIC_INT64_FEATURES = 1000180000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_FLOAT16_INT8_FEATURES = 1000082000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FLOAT_CONTROLS_PROPERTIES = 1000197000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_BINDING_FLAGS_CREATE_INFO = 1000161000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_INDEXING_FEATURES = 1000161001,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_INDEXING_PROPERTIES = 1000161002,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_DESCRIPTOR_SET_VARIABLE_DESCRIPTOR_COUNT_ALLOCATE_INFO =
            1000161003,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_DESCRIPTOR_SET_VARIABLE_DESCRIPTOR_COUNT_LAYOUT_SUPPORT =
            1000161004,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEPTH_STENCIL_RESOLVE_PROPERTIES = 1000199000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SUBPASS_DESCRIPTION_DEPTH_STENCIL_RESOLVE = 1000199001,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SCALAR_BLOCK_LAYOUT_FEATURES = 1000221000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_IMAGE_STENCIL_USAGE_CREATE_INFO = 1000246000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLER_FILTER_MINMAX_PROPERTIES = 1000130000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SAMPLER_REDUCTION_MODE_CREATE_INFO = 1000130001,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_MEMORY_MODEL_FEATURES = 1000211000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGELESS_FRAMEBUFFER_FEATURES = 1000108000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_FRAMEBUFFER_ATTACHMENTS_CREATE_INFO = 1000108001,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_FRAMEBUFFER_ATTACHMENT_IMAGE_INFO = 1000108002,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_RENDER_PASS_ATTACHMENT_BEGIN_INFO = 1000108003,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_UNIFORM_BUFFER_STANDARD_LAYOUT_FEATURES =
            1000253000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_SUBGROUP_EXTENDED_TYPES_FEATURES =
            1000175000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SEPARATE_DEPTH_STENCIL_LAYOUTS_FEATURES =
            1000241000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_ATTACHMENT_REFERENCE_STENCIL_LAYOUT = 1000241001,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_ATTACHMENT_DESCRIPTION_STENCIL_LAYOUT = 1000241002,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_HOST_QUERY_RESET_FEATURES = 1000261000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TIMELINE_SEMAPHORE_FEATURES = 1000207000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TIMELINE_SEMAPHORE_PROPERTIES = 1000207001,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SEMAPHORE_TYPE_CREATE_INFO = 1000207002,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_TIMELINE_SEMAPHORE_SUBMIT_INFO = 1000207003,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SEMAPHORE_WAIT_INFO = 1000207004,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SEMAPHORE_SIGNAL_INFO = 1000207005,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BUFFER_DEVICE_ADDRESS_FEATURES = 1000257000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_BUFFER_DEVICE_ADDRESS_INFO = 1000244001,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_BUFFER_OPAQUE_CAPTURE_ADDRESS_CREATE_INFO = 1000257002,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_MEMORY_OPAQUE_CAPTURE_ADDRESS_ALLOCATE_INFO = 1000257003,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_DEVICE_MEMORY_OPAQUE_CAPTURE_ADDRESS_INFO = 1000257004,

        // Provided by VK_KHR_swapchain
        VK_STRUCTURE_TYPE_SWAPCHAIN_CREATE_INFO_KHR = 1000001000,

        // Provided by VK_KHR_swapchain
        VK_STRUCTURE_TYPE_PRESENT_INFO_KHR = 1000001001,

        // Provided by VK_KHR_swapchain with VK_VERSION_1_1, VK_KHR_device_group with VK_KHR_surface
        VK_STRUCTURE_TYPE_DEVICE_GROUP_PRESENT_CAPABILITIES_KHR = 1000060007,

        // Provided by VK_KHR_swapchain with VK_VERSION_1_1, VK_KHR_device_group with VK_KHR_swapchain
        VK_STRUCTURE_TYPE_IMAGE_SWAPCHAIN_CREATE_INFO_KHR = 1000060008,

        // Provided by VK_KHR_swapchain with VK_VERSION_1_1, VK_KHR_device_group with VK_KHR_swapchain
        VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_SWAPCHAIN_INFO_KHR = 1000060009,

        // Provided by VK_KHR_swapchain with VK_VERSION_1_1, VK_KHR_device_group with VK_KHR_swapchain
        VK_STRUCTURE_TYPE_ACQUIRE_NEXT_IMAGE_INFO_KHR = 1000060010,

        // Provided by VK_KHR_swapchain with VK_VERSION_1_1, VK_KHR_device_group with VK_KHR_swapchain
        VK_STRUCTURE_TYPE_DEVICE_GROUP_PRESENT_INFO_KHR = 1000060011,

        // Provided by VK_KHR_swapchain with VK_VERSION_1_1, VK_KHR_device_group with VK_KHR_swapchain
        VK_STRUCTURE_TYPE_DEVICE_GROUP_SWAPCHAIN_CREATE_INFO_KHR = 1000060012,

        // Provided by VK_KHR_display
        VK_STRUCTURE_TYPE_DISPLAY_MODE_CREATE_INFO_KHR = 1000002000,

        // Provided by VK_KHR_display
        VK_STRUCTURE_TYPE_DISPLAY_SURFACE_CREATE_INFO_KHR = 1000002001,

        // Provided by VK_KHR_display_swapchain
        VK_STRUCTURE_TYPE_DISPLAY_PRESENT_INFO_KHR = 1000003000,

        // Provided by VK_KHR_xlib_surface
        VK_STRUCTURE_TYPE_XLIB_SURFACE_CREATE_INFO_KHR = 1000004000,

        // Provided by VK_KHR_xcb_surface
        VK_STRUCTURE_TYPE_XCB_SURFACE_CREATE_INFO_KHR = 1000005000,

        // Provided by VK_KHR_wayland_surface
        VK_STRUCTURE_TYPE_WAYLAND_SURFACE_CREATE_INFO_KHR = 1000006000,

        // Provided by VK_KHR_android_surface
        VK_STRUCTURE_TYPE_ANDROID_SURFACE_CREATE_INFO_KHR = 1000008000,

        // Provided by VK_KHR_win32_surface
        VK_STRUCTURE_TYPE_WIN32_SURFACE_CREATE_INFO_KHR = 1000009000,

        // Provided by VK_EXT_debug_report
        VK_STRUCTURE_TYPE_DEBUG_REPORT_CALLBACK_CREATE_INFO_EXT = 1000011000,

        // Provided by VK_AMD_rasterization_order
        VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_RASTERIZATION_ORDER_AMD =
            1000018000,

        // Provided by VK_EXT_debug_marker
        VK_STRUCTURE_TYPE_DEBUG_MARKER_OBJECT_NAME_INFO_EXT = 1000022000,

        // Provided by VK_EXT_debug_marker
        VK_STRUCTURE_TYPE_DEBUG_MARKER_OBJECT_TAG_INFO_EXT = 1000022001,

        // Provided by VK_EXT_debug_marker
        VK_STRUCTURE_TYPE_DEBUG_MARKER_MARKER_INFO_EXT = 1000022002,

        // Provided by VK_KHR_video_queue
        VK_STRUCTURE_TYPE_VIDEO_PROFILE_KHR = 1000023000,

        // Provided by VK_KHR_video_queue
        VK_STRUCTURE_TYPE_VIDEO_CAPABILITIES_KHR = 1000023001,

        // Provided by VK_KHR_video_queue
        VK_STRUCTURE_TYPE_VIDEO_PICTURE_RESOURCE_KHR = 1000023002,

        // Provided by VK_KHR_video_queue
        VK_STRUCTURE_TYPE_VIDEO_GET_MEMORY_PROPERTIES_KHR = 1000023003,

        // Provided by VK_KHR_video_queue
        VK_STRUCTURE_TYPE_VIDEO_BIND_MEMORY_KHR = 1000023004,

        // Provided by VK_KHR_video_queue
        VK_STRUCTURE_TYPE_VIDEO_SESSION_CREATE_INFO_KHR = 1000023005,

        // Provided by VK_KHR_video_queue
        VK_STRUCTURE_TYPE_VIDEO_SESSION_PARAMETERS_CREATE_INFO_KHR = 1000023006,

        // Provided by VK_KHR_video_queue
        VK_STRUCTURE_TYPE_VIDEO_SESSION_PARAMETERS_UPDATE_INFO_KHR = 1000023007,

        // Provided by VK_KHR_video_queue
        VK_STRUCTURE_TYPE_VIDEO_BEGIN_CODING_INFO_KHR = 1000023008,

        // Provided by VK_KHR_video_queue
        VK_STRUCTURE_TYPE_VIDEO_END_CODING_INFO_KHR = 1000023009,

        // Provided by VK_KHR_video_queue
        VK_STRUCTURE_TYPE_VIDEO_CODING_CONTROL_INFO_KHR = 1000023010,

        // Provided by VK_KHR_video_queue
        VK_STRUCTURE_TYPE_VIDEO_REFERENCE_SLOT_KHR = 1000023011,

        // Provided by VK_KHR_video_queue
        VK_STRUCTURE_TYPE_VIDEO_QUEUE_FAMILY_PROPERTIES_2_KHR = 1000023012,

        // Provided by VK_KHR_video_queue
        VK_STRUCTURE_TYPE_VIDEO_PROFILES_KHR = 1000023013,

        // Provided by VK_KHR_video_queue
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VIDEO_FORMAT_INFO_KHR = 1000023014,

        // Provided by VK_KHR_video_queue
        VK_STRUCTURE_TYPE_VIDEO_FORMAT_PROPERTIES_KHR = 1000023015,

        // Provided by VK_KHR_video_decode_queue
        VK_STRUCTURE_TYPE_VIDEO_DECODE_INFO_KHR = 1000024000,

        // Provided by VK_NV_dedicated_allocation
        VK_STRUCTURE_TYPE_DEDICATED_ALLOCATION_IMAGE_CREATE_INFO_NV = 1000026000,

        // Provided by VK_NV_dedicated_allocation
        VK_STRUCTURE_TYPE_DEDICATED_ALLOCATION_BUFFER_CREATE_INFO_NV = 1000026001,

        // Provided by VK_NV_dedicated_allocation
        VK_STRUCTURE_TYPE_DEDICATED_ALLOCATION_MEMORY_ALLOCATE_INFO_NV = 1000026002,

        // Provided by VK_EXT_transform_feedback
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TRANSFORM_FEEDBACK_FEATURES_EXT = 1000028000,

        // Provided by VK_EXT_transform_feedback
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TRANSFORM_FEEDBACK_PROPERTIES_EXT = 1000028001,

        // Provided by VK_EXT_transform_feedback
        VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_STREAM_CREATE_INFO_EXT =
            1000028002,

        // Provided by VK_NVX_binary_import
        VK_STRUCTURE_TYPE_CU_MODULE_CREATE_INFO_NVX = 1000029000,

        // Provided by VK_NVX_binary_import
        VK_STRUCTURE_TYPE_CU_FUNCTION_CREATE_INFO_NVX = 1000029001,

        // Provided by VK_NVX_binary_import
        VK_STRUCTURE_TYPE_CU_LAUNCH_INFO_NVX = 1000029002,

        // Provided by VK_NVX_image_view_handle
        VK_STRUCTURE_TYPE_IMAGE_VIEW_HANDLE_INFO_NVX = 1000030000,

        // Provided by VK_NVX_image_view_handle
        VK_STRUCTURE_TYPE_IMAGE_VIEW_ADDRESS_PROPERTIES_NVX = 1000030001,

        // Provided by VK_EXT_video_encode_h264
        VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_CAPABILITIES_EXT = 1000038000,

        // Provided by VK_EXT_video_encode_h264
        VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_SESSION_CREATE_INFO_EXT = 1000038001,

        // Provided by VK_EXT_video_encode_h264
        VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_SESSION_PARAMETERS_CREATE_INFO_EXT =
            1000038002,

        // Provided by VK_EXT_video_encode_h264
        VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_SESSION_PARAMETERS_ADD_INFO_EXT = 1000038003,

        // Provided by VK_EXT_video_encode_h264
        VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_VCL_FRAME_INFO_EXT = 1000038004,

        // Provided by VK_EXT_video_encode_h264
        VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_DPB_SLOT_INFO_EXT = 1000038005,

        // Provided by VK_EXT_video_encode_h264
        VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_NALU_SLICE_EXT = 1000038006,

        // Provided by VK_EXT_video_encode_h264
        VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_EMIT_PICTURE_PARAMETERS_EXT = 1000038007,

        // Provided by VK_EXT_video_encode_h264
        VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_PROFILE_EXT = 1000038008,

        // Provided by VK_EXT_video_decode_h264
        VK_STRUCTURE_TYPE_VIDEO_DECODE_H264_CAPABILITIES_EXT = 1000040000,

        // Provided by VK_EXT_video_decode_h264
        VK_STRUCTURE_TYPE_VIDEO_DECODE_H264_SESSION_CREATE_INFO_EXT = 1000040001,

        // Provided by VK_EXT_video_decode_h264
        VK_STRUCTURE_TYPE_VIDEO_DECODE_H264_PICTURE_INFO_EXT = 1000040002,

        // Provided by VK_EXT_video_decode_h264
        VK_STRUCTURE_TYPE_VIDEO_DECODE_H264_MVC_EXT = 1000040003,

        // Provided by VK_EXT_video_decode_h264
        VK_STRUCTURE_TYPE_VIDEO_DECODE_H264_PROFILE_EXT = 1000040004,

        // Provided by VK_EXT_video_decode_h264
        VK_STRUCTURE_TYPE_VIDEO_DECODE_H264_SESSION_PARAMETERS_CREATE_INFO_EXT =
            1000040005,

        // Provided by VK_EXT_video_decode_h264
        VK_STRUCTURE_TYPE_VIDEO_DECODE_H264_SESSION_PARAMETERS_ADD_INFO_EXT = 1000040006,

        // Provided by VK_EXT_video_decode_h264
        VK_STRUCTURE_TYPE_VIDEO_DECODE_H264_DPB_SLOT_INFO_EXT = 1000040007,

        // Provided by VK_AMD_texture_gather_bias_lod
        VK_STRUCTURE_TYPE_TEXTURE_LOD_GATHER_FORMAT_PROPERTIES_AMD = 1000041000,

        // Provided by VK_GGP_stream_descriptor_surface
        VK_STRUCTURE_TYPE_STREAM_DESCRIPTOR_SURFACE_CREATE_INFO_GGP = 1000049000,

        // Provided by VK_NV_corner_sampled_image
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CORNER_SAMPLED_IMAGE_FEATURES_NV = 1000050000,

        // Provided by VK_NV_external_memory
        VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_IMAGE_CREATE_INFO_NV = 1000056000,

        // Provided by VK_NV_external_memory
        VK_STRUCTURE_TYPE_EXPORT_MEMORY_ALLOCATE_INFO_NV = 1000056001,

        // Provided by VK_NV_external_memory_win32
        VK_STRUCTURE_TYPE_IMPORT_MEMORY_WIN32_HANDLE_INFO_NV = 1000057000,

        // Provided by VK_NV_external_memory_win32
        VK_STRUCTURE_TYPE_EXPORT_MEMORY_WIN32_HANDLE_INFO_NV = 1000057001,

        // Provided by VK_NV_win32_keyed_mutex
        VK_STRUCTURE_TYPE_WIN32_KEYED_MUTEX_ACQUIRE_RELEASE_INFO_NV = 1000058000,

        // Provided by VK_EXT_validation_flags
        VK_STRUCTURE_TYPE_VALIDATION_FLAGS_EXT = 1000061000,

        // Provided by VK_NN_vi_surface
        VK_STRUCTURE_TYPE_VI_SURFACE_CREATE_INFO_NN = 1000062000,

        // Provided by VK_EXT_texture_compression_astc_hdr
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TEXTURE_COMPRESSION_ASTC_HDR_FEATURES_EXT =
            1000066000,

        // Provided by VK_EXT_astc_decode_mode
        VK_STRUCTURE_TYPE_IMAGE_VIEW_ASTC_DECODE_MODE_EXT = 1000067000,

        // Provided by VK_EXT_astc_decode_mode
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ASTC_DECODE_FEATURES_EXT = 1000067001,

        // Provided by VK_KHR_external_memory_win32
        VK_STRUCTURE_TYPE_IMPORT_MEMORY_WIN32_HANDLE_INFO_KHR = 1000073000,

        // Provided by VK_KHR_external_memory_win32
        VK_STRUCTURE_TYPE_EXPORT_MEMORY_WIN32_HANDLE_INFO_KHR = 1000073001,

        // Provided by VK_KHR_external_memory_win32
        VK_STRUCTURE_TYPE_MEMORY_WIN32_HANDLE_PROPERTIES_KHR = 1000073002,

        // Provided by VK_KHR_external_memory_win32
        VK_STRUCTURE_TYPE_MEMORY_GET_WIN32_HANDLE_INFO_KHR = 1000073003,

        // Provided by VK_KHR_external_memory_fd
        VK_STRUCTURE_TYPE_IMPORT_MEMORY_FD_INFO_KHR = 1000074000,

        // Provided by VK_KHR_external_memory_fd
        VK_STRUCTURE_TYPE_MEMORY_FD_PROPERTIES_KHR = 1000074001,

        // Provided by VK_KHR_external_memory_fd
        VK_STRUCTURE_TYPE_MEMORY_GET_FD_INFO_KHR = 1000074002,

        // Provided by VK_KHR_win32_keyed_mutex
        VK_STRUCTURE_TYPE_WIN32_KEYED_MUTEX_ACQUIRE_RELEASE_INFO_KHR = 1000075000,

        // Provided by VK_KHR_external_semaphore_win32
        VK_STRUCTURE_TYPE_IMPORT_SEMAPHORE_WIN32_HANDLE_INFO_KHR = 1000078000,

        // Provided by VK_KHR_external_semaphore_win32
        VK_STRUCTURE_TYPE_EXPORT_SEMAPHORE_WIN32_HANDLE_INFO_KHR = 1000078001,

        // Provided by VK_KHR_external_semaphore_win32
        VK_STRUCTURE_TYPE_D3D12_FENCE_SUBMIT_INFO_KHR = 1000078002,

        // Provided by VK_KHR_external_semaphore_win32
        VK_STRUCTURE_TYPE_SEMAPHORE_GET_WIN32_HANDLE_INFO_KHR = 1000078003,

        // Provided by VK_KHR_external_semaphore_fd
        VK_STRUCTURE_TYPE_IMPORT_SEMAPHORE_FD_INFO_KHR = 1000079000,

        // Provided by VK_KHR_external_semaphore_fd
        VK_STRUCTURE_TYPE_SEMAPHORE_GET_FD_INFO_KHR = 1000079001,

        // Provided by VK_KHR_push_descriptor
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PUSH_DESCRIPTOR_PROPERTIES_KHR = 1000080000,

        // Provided by VK_EXT_conditional_rendering
        VK_STRUCTURE_TYPE_COMMAND_BUFFER_INHERITANCE_CONDITIONAL_RENDERING_INFO_EXT =
            1000081000,

        // Provided by VK_EXT_conditional_rendering
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CONDITIONAL_RENDERING_FEATURES_EXT = 1000081001,

        // Provided by VK_EXT_conditional_rendering
        VK_STRUCTURE_TYPE_CONDITIONAL_RENDERING_BEGIN_INFO_EXT = 1000081002,

        // Provided by VK_KHR_incremental_present
        VK_STRUCTURE_TYPE_PRESENT_REGIONS_KHR = 1000084000,

        // Provided by VK_NV_clip_space_w_scaling
        VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_W_SCALING_STATE_CREATE_INFO_NV = 1000087000,

        // Provided by VK_EXT_display_surface_counter
        VK_STRUCTURE_TYPE_SURFACE_CAPABILITIES_2_EXT = 1000090000,

        // Provided by VK_EXT_display_control
        VK_STRUCTURE_TYPE_DISPLAY_POWER_INFO_EXT = 1000091000,

        // Provided by VK_EXT_display_control
        VK_STRUCTURE_TYPE_DEVICE_EVENT_INFO_EXT = 1000091001,

        // Provided by VK_EXT_display_control
        VK_STRUCTURE_TYPE_DISPLAY_EVENT_INFO_EXT = 1000091002,

        // Provided by VK_EXT_display_control
        VK_STRUCTURE_TYPE_SWAPCHAIN_COUNTER_CREATE_INFO_EXT = 1000091003,

        // Provided by VK_GOOGLE_display_timing
        VK_STRUCTURE_TYPE_PRESENT_TIMES_INFO_GOOGLE = 1000092000,

        // Provided by VK_NVX_multiview_per_view_attributes
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_PER_VIEW_ATTRIBUTES_PROPERTIES_NVX =
            1000097000,

        // Provided by VK_NV_viewport_swizzle
        VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_SWIZZLE_STATE_CREATE_INFO_NV = 1000098000,

        // Provided by VK_EXT_discard_rectangles
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DISCARD_RECTANGLE_PROPERTIES_EXT = 1000099000,

        // Provided by VK_EXT_discard_rectangles
        VK_STRUCTURE_TYPE_PIPELINE_DISCARD_RECTANGLE_STATE_CREATE_INFO_EXT = 1000099001,

        // Provided by VK_EXT_conservative_rasterization
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CONSERVATIVE_RASTERIZATION_PROPERTIES_EXT =
            1000101000,

        // Provided by VK_EXT_conservative_rasterization
        VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_CONSERVATIVE_STATE_CREATE_INFO_EXT =
            1000101001,

        // Provided by VK_EXT_depth_clip_enable
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEPTH_CLIP_ENABLE_FEATURES_EXT = 1000102000,

        // Provided by VK_EXT_depth_clip_enable
        VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_DEPTH_CLIP_STATE_CREATE_INFO_EXT =
            1000102001,

        // Provided by VK_EXT_hdr_metadata
        VK_STRUCTURE_TYPE_HDR_METADATA_EXT = 1000105000,

        // Provided by VK_KHR_shared_presentable_image
        VK_STRUCTURE_TYPE_SHARED_PRESENT_SURFACE_CAPABILITIES_KHR = 1000111000,

        // Provided by VK_KHR_external_fence_win32
        VK_STRUCTURE_TYPE_IMPORT_FENCE_WIN32_HANDLE_INFO_KHR = 1000114000,

        // Provided by VK_KHR_external_fence_win32
        VK_STRUCTURE_TYPE_EXPORT_FENCE_WIN32_HANDLE_INFO_KHR = 1000114001,

        // Provided by VK_KHR_external_fence_win32
        VK_STRUCTURE_TYPE_FENCE_GET_WIN32_HANDLE_INFO_KHR = 1000114002,

        // Provided by VK_KHR_external_fence_fd
        VK_STRUCTURE_TYPE_IMPORT_FENCE_FD_INFO_KHR = 1000115000,

        // Provided by VK_KHR_external_fence_fd
        VK_STRUCTURE_TYPE_FENCE_GET_FD_INFO_KHR = 1000115001,

        // Provided by VK_KHR_performance_query
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PERFORMANCE_QUERY_FEATURES_KHR = 1000116000,

        // Provided by VK_KHR_performance_query
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PERFORMANCE_QUERY_PROPERTIES_KHR = 1000116001,

        // Provided by VK_KHR_performance_query
        VK_STRUCTURE_TYPE_QUERY_POOL_PERFORMANCE_CREATE_INFO_KHR = 1000116002,

        // Provided by VK_KHR_performance_query
        VK_STRUCTURE_TYPE_PERFORMANCE_QUERY_SUBMIT_INFO_KHR = 1000116003,

        // Provided by VK_KHR_performance_query
        VK_STRUCTURE_TYPE_ACQUIRE_PROFILING_LOCK_INFO_KHR = 1000116004,

        // Provided by VK_KHR_performance_query
        VK_STRUCTURE_TYPE_PERFORMANCE_COUNTER_KHR = 1000116005,

        // Provided by VK_KHR_performance_query
        VK_STRUCTURE_TYPE_PERFORMANCE_COUNTER_DESCRIPTION_KHR = 1000116006,

        // Provided by VK_KHR_get_surface_capabilities2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SURFACE_INFO_2_KHR = 1000119000,

        // Provided by VK_KHR_get_surface_capabilities2
        VK_STRUCTURE_TYPE_SURFACE_CAPABILITIES_2_KHR = 1000119001,

        // Provided by VK_KHR_get_surface_capabilities2
        VK_STRUCTURE_TYPE_SURFACE_FORMAT_2_KHR = 1000119002,

        // Provided by VK_KHR_get_display_properties2
        VK_STRUCTURE_TYPE_DISPLAY_PROPERTIES_2_KHR = 1000121000,

        // Provided by VK_KHR_get_display_properties2
        VK_STRUCTURE_TYPE_DISPLAY_PLANE_PROPERTIES_2_KHR = 1000121001,

        // Provided by VK_KHR_get_display_properties2
        VK_STRUCTURE_TYPE_DISPLAY_MODE_PROPERTIES_2_KHR = 1000121002,

        // Provided by VK_KHR_get_display_properties2
        VK_STRUCTURE_TYPE_DISPLAY_PLANE_INFO_2_KHR = 1000121003,

        // Provided by VK_KHR_get_display_properties2
        VK_STRUCTURE_TYPE_DISPLAY_PLANE_CAPABILITIES_2_KHR = 1000121004,

        // Provided by VK_MVK_ios_surface
        VK_STRUCTURE_TYPE_IOS_SURFACE_CREATE_INFO_MVK = 1000122000,

        // Provided by VK_MVK_macos_surface
        VK_STRUCTURE_TYPE_MACOS_SURFACE_CREATE_INFO_MVK = 1000123000,

        // Provided by VK_EXT_debug_utils
        VK_STRUCTURE_TYPE_DEBUG_UTILS_OBJECT_NAME_INFO_EXT = 1000128000,

        // Provided by VK_EXT_debug_utils
        VK_STRUCTURE_TYPE_DEBUG_UTILS_OBJECT_TAG_INFO_EXT = 1000128001,

        // Provided by VK_EXT_debug_utils
        VK_STRUCTURE_TYPE_DEBUG_UTILS_LABEL_EXT = 1000128002,

        // Provided by VK_EXT_debug_utils
        VK_STRUCTURE_TYPE_DEBUG_UTILS_MESSENGER_CALLBACK_DATA_EXT = 1000128003,

        // Provided by VK_EXT_debug_utils
        VK_STRUCTURE_TYPE_DEBUG_UTILS_MESSENGER_CREATE_INFO_EXT = 1000128004,

        // Provided by VK_ANDROID_external_memory_android_hardware_buffer
        VK_STRUCTURE_TYPE_ANDROID_HARDWARE_BUFFER_USAGE_ANDROID = 1000129000,

        // Provided by VK_ANDROID_external_memory_android_hardware_buffer
        VK_STRUCTURE_TYPE_ANDROID_HARDWARE_BUFFER_PROPERTIES_ANDROID = 1000129001,

        // Provided by VK_ANDROID_external_memory_android_hardware_buffer
        VK_STRUCTURE_TYPE_ANDROID_HARDWARE_BUFFER_FORMAT_PROPERTIES_ANDROID = 1000129002,

        // Provided by VK_ANDROID_external_memory_android_hardware_buffer
        VK_STRUCTURE_TYPE_IMPORT_ANDROID_HARDWARE_BUFFER_INFO_ANDROID = 1000129003,

        // Provided by VK_ANDROID_external_memory_android_hardware_buffer
        VK_STRUCTURE_TYPE_MEMORY_GET_ANDROID_HARDWARE_BUFFER_INFO_ANDROID = 1000129004,

        // Provided by VK_ANDROID_external_memory_android_hardware_buffer
        VK_STRUCTURE_TYPE_EXTERNAL_FORMAT_ANDROID = 1000129005,

        // Provided by VK_EXT_inline_uniform_block
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INLINE_UNIFORM_BLOCK_FEATURES_EXT = 1000138000,

        // Provided by VK_EXT_inline_uniform_block
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INLINE_UNIFORM_BLOCK_PROPERTIES_EXT =
            1000138001,

        // Provided by VK_EXT_inline_uniform_block
        VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET_INLINE_UNIFORM_BLOCK_EXT = 1000138002,

        // Provided by VK_EXT_inline_uniform_block
        VK_STRUCTURE_TYPE_DESCRIPTOR_POOL_INLINE_UNIFORM_BLOCK_CREATE_INFO_EXT =
            1000138003,

        // Provided by VK_EXT_sample_locations
        VK_STRUCTURE_TYPE_SAMPLE_LOCATIONS_INFO_EXT = 1000143000,

        // Provided by VK_EXT_sample_locations
        VK_STRUCTURE_TYPE_RENDER_PASS_SAMPLE_LOCATIONS_BEGIN_INFO_EXT = 1000143001,

        // Provided by VK_EXT_sample_locations
        VK_STRUCTURE_TYPE_PIPELINE_SAMPLE_LOCATIONS_STATE_CREATE_INFO_EXT = 1000143002,

        // Provided by VK_EXT_sample_locations
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLE_LOCATIONS_PROPERTIES_EXT = 1000143003,

        // Provided by VK_EXT_sample_locations
        VK_STRUCTURE_TYPE_MULTISAMPLE_PROPERTIES_EXT = 1000143004,

        // Provided by VK_EXT_blend_operation_advanced
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BLEND_OPERATION_ADVANCED_FEATURES_EXT =
            1000148000,

        // Provided by VK_EXT_blend_operation_advanced
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BLEND_OPERATION_ADVANCED_PROPERTIES_EXT =
            1000148001,

        // Provided by VK_EXT_blend_operation_advanced
        VK_STRUCTURE_TYPE_PIPELINE_COLOR_BLEND_ADVANCED_STATE_CREATE_INFO_EXT =
            1000148002,

        // Provided by VK_NV_fragment_coverage_to_color
        VK_STRUCTURE_TYPE_PIPELINE_COVERAGE_TO_COLOR_STATE_CREATE_INFO_NV = 1000149000,

        // Provided by VK_KHR_acceleration_structure
        VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET_ACCELERATION_STRUCTURE_KHR = 1000150007,

        // Provided by VK_KHR_acceleration_structure
        VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_BUILD_GEOMETRY_INFO_KHR = 1000150000,

        // Provided by VK_KHR_acceleration_structure
        VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_DEVICE_ADDRESS_INFO_KHR = 1000150002,

        // Provided by VK_KHR_acceleration_structure
        VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_GEOMETRY_AABBS_DATA_KHR = 1000150003,

        // Provided by VK_KHR_acceleration_structure
        VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_GEOMETRY_INSTANCES_DATA_KHR = 1000150004,

        // Provided by VK_KHR_acceleration_structure
        VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_GEOMETRY_TRIANGLES_DATA_KHR = 1000150005,

        // Provided by VK_KHR_acceleration_structure
        VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_GEOMETRY_KHR = 1000150006,

        // Provided by VK_KHR_acceleration_structure
        VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_VERSION_INFO_KHR = 1000150009,

        // Provided by VK_KHR_acceleration_structure
        VK_STRUCTURE_TYPE_COPY_ACCELERATION_STRUCTURE_INFO_KHR = 1000150010,

        // Provided by VK_KHR_acceleration_structure
        VK_STRUCTURE_TYPE_COPY_ACCELERATION_STRUCTURE_TO_MEMORY_INFO_KHR = 1000150011,

        // Provided by VK_KHR_acceleration_structure
        VK_STRUCTURE_TYPE_COPY_MEMORY_TO_ACCELERATION_STRUCTURE_INFO_KHR = 1000150012,

        // Provided by VK_KHR_acceleration_structure
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ACCELERATION_STRUCTURE_FEATURES_KHR =
            1000150013,

        // Provided by VK_KHR_acceleration_structure
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ACCELERATION_STRUCTURE_PROPERTIES_KHR =
            1000150014,

        // Provided by VK_KHR_acceleration_structure
        VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_CREATE_INFO_KHR = 1000150017,

        // Provided by VK_KHR_acceleration_structure
        VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_BUILD_SIZES_INFO_KHR = 1000150020,

        // Provided by VK_KHR_ray_tracing_pipeline
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RAY_TRACING_PIPELINE_FEATURES_KHR = 1000347000,

        // Provided by VK_KHR_ray_tracing_pipeline
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RAY_TRACING_PIPELINE_PROPERTIES_KHR =
            1000347001,

        // Provided by VK_KHR_ray_tracing_pipeline
        VK_STRUCTURE_TYPE_RAY_TRACING_PIPELINE_CREATE_INFO_KHR = 1000150015,

        // Provided by VK_KHR_ray_tracing_pipeline
        VK_STRUCTURE_TYPE_RAY_TRACING_SHADER_GROUP_CREATE_INFO_KHR = 1000150016,

        // Provided by VK_KHR_ray_tracing_pipeline
        VK_STRUCTURE_TYPE_RAY_TRACING_PIPELINE_INTERFACE_CREATE_INFO_KHR = 1000150018,

        // Provided by VK_KHR_ray_query
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RAY_QUERY_FEATURES_KHR = 1000348013,

        // Provided by VK_NV_framebuffer_mixed_samples
        VK_STRUCTURE_TYPE_PIPELINE_COVERAGE_MODULATION_STATE_CREATE_INFO_NV = 1000152000,

        // Provided by VK_NV_shader_sm_builtins
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_SM_BUILTINS_FEATURES_NV = 1000154000,

        // Provided by VK_NV_shader_sm_builtins
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_SM_BUILTINS_PROPERTIES_NV = 1000154001,

        // Provided by VK_EXT_image_drm_format_modifier
        VK_STRUCTURE_TYPE_DRM_FORMAT_MODIFIER_PROPERTIES_LIST_EXT = 1000158000,

        // Provided by VK_EXT_image_drm_format_modifier
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_DRM_FORMAT_MODIFIER_INFO_EXT = 1000158002,

        // Provided by VK_EXT_image_drm_format_modifier
        VK_STRUCTURE_TYPE_IMAGE_DRM_FORMAT_MODIFIER_LIST_CREATE_INFO_EXT = 1000158003,

        // Provided by VK_EXT_image_drm_format_modifier
        VK_STRUCTURE_TYPE_IMAGE_DRM_FORMAT_MODIFIER_EXPLICIT_CREATE_INFO_EXT = 1000158004,

        // Provided by VK_EXT_image_drm_format_modifier
        VK_STRUCTURE_TYPE_IMAGE_DRM_FORMAT_MODIFIER_PROPERTIES_EXT = 1000158005,

        // Provided by VK_EXT_validation_cache
        VK_STRUCTURE_TYPE_VALIDATION_CACHE_CREATE_INFO_EXT = 1000160000,

        // Provided by VK_EXT_validation_cache
        VK_STRUCTURE_TYPE_SHADER_MODULE_VALIDATION_CACHE_CREATE_INFO_EXT = 1000160001,

        // Provided by VK_KHR_portability_subset
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PORTABILITY_SUBSET_FEATURES_KHR = 1000163000,

        // Provided by VK_KHR_portability_subset
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PORTABILITY_SUBSET_PROPERTIES_KHR = 1000163001,

        // Provided by VK_NV_shading_rate_image
        VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_SHADING_RATE_IMAGE_STATE_CREATE_INFO_NV =
            1000164000,

        // Provided by VK_NV_shading_rate_image
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADING_RATE_IMAGE_FEATURES_NV = 1000164001,

        // Provided by VK_NV_shading_rate_image
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADING_RATE_IMAGE_PROPERTIES_NV = 1000164002,

        // Provided by VK_NV_shading_rate_image
        VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_COARSE_SAMPLE_ORDER_STATE_CREATE_INFO_NV =
            1000164005,

        // Provided by VK_NV_ray_tracing
        VK_STRUCTURE_TYPE_RAY_TRACING_PIPELINE_CREATE_INFO_NV = 1000165000,

        // Provided by VK_NV_ray_tracing
        VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_CREATE_INFO_NV = 1000165001,

        // Provided by VK_NV_ray_tracing
        VK_STRUCTURE_TYPE_GEOMETRY_NV = 1000165003,

        // Provided by VK_NV_ray_tracing
        VK_STRUCTURE_TYPE_GEOMETRY_TRIANGLES_NV = 1000165004,

        // Provided by VK_NV_ray_tracing
        VK_STRUCTURE_TYPE_GEOMETRY_AABB_NV = 1000165005,

        // Provided by VK_NV_ray_tracing
        VK_STRUCTURE_TYPE_BIND_ACCELERATION_STRUCTURE_MEMORY_INFO_NV = 1000165006,

        // Provided by VK_NV_ray_tracing
        VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET_ACCELERATION_STRUCTURE_NV = 1000165007,

        // Provided by VK_NV_ray_tracing
        VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_MEMORY_REQUIREMENTS_INFO_NV = 1000165008,

        // Provided by VK_NV_ray_tracing
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RAY_TRACING_PROPERTIES_NV = 1000165009,

        // Provided by VK_NV_ray_tracing
        VK_STRUCTURE_TYPE_RAY_TRACING_SHADER_GROUP_CREATE_INFO_NV = 1000165011,

        // Provided by VK_NV_ray_tracing
        VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_INFO_NV = 1000165012,

        // Provided by VK_NV_representative_fragment_test
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_REPRESENTATIVE_FRAGMENT_TEST_FEATURES_NV =
            1000166000,

        // Provided by VK_NV_representative_fragment_test
        VK_STRUCTURE_TYPE_PIPELINE_REPRESENTATIVE_FRAGMENT_TEST_STATE_CREATE_INFO_NV =
            1000166001,

        // Provided by VK_EXT_filter_cubic
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_VIEW_IMAGE_FORMAT_INFO_EXT = 1000170000,

        // Provided by VK_EXT_filter_cubic
        VK_STRUCTURE_TYPE_FILTER_CUBIC_IMAGE_VIEW_IMAGE_FORMAT_PROPERTIES_EXT =
            1000170001,

        // Provided by VK_EXT_global_priority
        VK_STRUCTURE_TYPE_DEVICE_QUEUE_GLOBAL_PRIORITY_CREATE_INFO_EXT = 1000174000,

        // Provided by VK_EXT_external_memory_host
        VK_STRUCTURE_TYPE_IMPORT_MEMORY_HOST_POINTER_INFO_EXT = 1000178000,

        // Provided by VK_EXT_external_memory_host
        VK_STRUCTURE_TYPE_MEMORY_HOST_POINTER_PROPERTIES_EXT = 1000178001,

        // Provided by VK_EXT_external_memory_host
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_MEMORY_HOST_PROPERTIES_EXT =
            1000178002,

        // Provided by VK_KHR_shader_clock
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_CLOCK_FEATURES_KHR = 1000181000,

        // Provided by VK_AMD_pipeline_compiler_control
        VK_STRUCTURE_TYPE_PIPELINE_COMPILER_CONTROL_CREATE_INFO_AMD = 1000183000,

        // Provided by VK_EXT_calibrated_timestamps
        VK_STRUCTURE_TYPE_CALIBRATED_TIMESTAMP_INFO_EXT = 1000184000,

        // Provided by VK_AMD_shader_core_properties
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_CORE_PROPERTIES_AMD = 1000185000,

        // Provided by VK_EXT_video_decode_h265
        VK_STRUCTURE_TYPE_VIDEO_DECODE_H265_CAPABILITIES_EXT = 1000187000,

        // Provided by VK_EXT_video_decode_h265
        VK_STRUCTURE_TYPE_VIDEO_DECODE_H265_SESSION_CREATE_INFO_EXT = 1000187001,

        // Provided by VK_EXT_video_decode_h265
        VK_STRUCTURE_TYPE_VIDEO_DECODE_H265_SESSION_PARAMETERS_CREATE_INFO_EXT =
            1000187002,

        // Provided by VK_EXT_video_decode_h265
        VK_STRUCTURE_TYPE_VIDEO_DECODE_H265_SESSION_PARAMETERS_ADD_INFO_EXT = 1000187003,

        // Provided by VK_EXT_video_decode_h265
        VK_STRUCTURE_TYPE_VIDEO_DECODE_H265_PROFILE_EXT = 1000187004,

        // Provided by VK_EXT_video_decode_h265
        VK_STRUCTURE_TYPE_VIDEO_DECODE_H265_PICTURE_INFO_EXT = 1000187005,

        // Provided by VK_EXT_video_decode_h265
        VK_STRUCTURE_TYPE_VIDEO_DECODE_H265_DPB_SLOT_INFO_EXT = 1000187006,

        // Provided by VK_AMD_memory_overallocation_behavior
        VK_STRUCTURE_TYPE_DEVICE_MEMORY_OVERALLOCATION_CREATE_INFO_AMD = 1000189000,

        // Provided by VK_EXT_vertex_attribute_divisor
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VERTEX_ATTRIBUTE_DIVISOR_PROPERTIES_EXT =
            1000190000,

        // Provided by VK_EXT_vertex_attribute_divisor
        VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_DIVISOR_STATE_CREATE_INFO_EXT =
            1000190001,

        // Provided by VK_EXT_vertex_attribute_divisor
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VERTEX_ATTRIBUTE_DIVISOR_FEATURES_EXT =
            1000190002,

        // Provided by VK_GGP_frame_token
        VK_STRUCTURE_TYPE_PRESENT_FRAME_TOKEN_GGP = 1000191000,

        // Provided by VK_EXT_pipeline_creation_feedback
        VK_STRUCTURE_TYPE_PIPELINE_CREATION_FEEDBACK_CREATE_INFO_EXT = 1000192000,

        // Provided by VK_NV_compute_shader_derivatives
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COMPUTE_SHADER_DERIVATIVES_FEATURES_NV =
            1000201000,

        // Provided by VK_NV_mesh_shader
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MESH_SHADER_FEATURES_NV = 1000202000,

        // Provided by VK_NV_mesh_shader
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MESH_SHADER_PROPERTIES_NV = 1000202001,

        // Provided by VK_NV_fragment_shader_barycentric
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_SHADER_BARYCENTRIC_FEATURES_NV =
            1000203000,

        // Provided by VK_NV_shader_image_footprint
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_IMAGE_FOOTPRINT_FEATURES_NV = 1000204000,

        // Provided by VK_NV_scissor_exclusive
        VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_EXCLUSIVE_SCISSOR_STATE_CREATE_INFO_NV =
            1000205000,

        // Provided by VK_NV_scissor_exclusive
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXCLUSIVE_SCISSOR_FEATURES_NV = 1000205002,

        // Provided by VK_NV_device_diagnostic_checkpoints
        VK_STRUCTURE_TYPE_CHECKPOINT_DATA_NV = 1000206000,

        // Provided by VK_NV_device_diagnostic_checkpoints
        VK_STRUCTURE_TYPE_QUEUE_FAMILY_CHECKPOINT_PROPERTIES_NV = 1000206001,

        // Provided by VK_INTEL_shader_integer_functions2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_INTEGER_FUNCTIONS_2_FEATURES_INTEL =
            1000209000,

        // Provided by VK_INTEL_performance_query
        VK_STRUCTURE_TYPE_QUERY_POOL_PERFORMANCE_QUERY_CREATE_INFO_INTEL = 1000210000,

        // Provided by VK_INTEL_performance_query
        VK_STRUCTURE_TYPE_INITIALIZE_PERFORMANCE_API_INFO_INTEL = 1000210001,

        // Provided by VK_INTEL_performance_query
        VK_STRUCTURE_TYPE_PERFORMANCE_MARKER_INFO_INTEL = 1000210002,

        // Provided by VK_INTEL_performance_query
        VK_STRUCTURE_TYPE_PERFORMANCE_STREAM_MARKER_INFO_INTEL = 1000210003,

        // Provided by VK_INTEL_performance_query
        VK_STRUCTURE_TYPE_PERFORMANCE_OVERRIDE_INFO_INTEL = 1000210004,

        // Provided by VK_INTEL_performance_query
        VK_STRUCTURE_TYPE_PERFORMANCE_CONFIGURATION_ACQUIRE_INFO_INTEL = 1000210005,

        // Provided by VK_EXT_pci_bus_info
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PCI_BUS_INFO_PROPERTIES_EXT = 1000212000,

        // Provided by VK_AMD_display_native_hdr
        VK_STRUCTURE_TYPE_DISPLAY_NATIVE_HDR_SURFACE_CAPABILITIES_AMD = 1000213000,

        // Provided by VK_AMD_display_native_hdr
        VK_STRUCTURE_TYPE_SWAPCHAIN_DISPLAY_NATIVE_HDR_CREATE_INFO_AMD = 1000213001,

        // Provided by VK_FUCHSIA_imagepipe_surface
        VK_STRUCTURE_TYPE_IMAGEPIPE_SURFACE_CREATE_INFO_FUCHSIA = 1000214000,

        // Provided by VK_KHR_shader_terminate_invocation
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_TERMINATE_INVOCATION_FEATURES_KHR =
            1000215000,

        // Provided by VK_EXT_metal_surface
        VK_STRUCTURE_TYPE_METAL_SURFACE_CREATE_INFO_EXT = 1000217000,

        // Provided by VK_EXT_fragment_density_map
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_DENSITY_MAP_FEATURES_EXT = 1000218000,

        // Provided by VK_EXT_fragment_density_map
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_DENSITY_MAP_PROPERTIES_EXT =
            1000218001,

        // Provided by VK_EXT_fragment_density_map
        VK_STRUCTURE_TYPE_RENDER_PASS_FRAGMENT_DENSITY_MAP_CREATE_INFO_EXT = 1000218002,

        // Provided by VK_EXT_subgroup_size_control
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SUBGROUP_SIZE_CONTROL_PROPERTIES_EXT =
            1000225000,

        // Provided by VK_EXT_subgroup_size_control
        VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_REQUIRED_SUBGROUP_SIZE_CREATE_INFO_EXT =
            1000225001,

        // Provided by VK_EXT_subgroup_size_control
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SUBGROUP_SIZE_CONTROL_FEATURES_EXT = 1000225002,

        // Provided by VK_KHR_fragment_shading_rate
        VK_STRUCTURE_TYPE_FRAGMENT_SHADING_RATE_ATTACHMENT_INFO_KHR = 1000226000,

        // Provided by VK_KHR_fragment_shading_rate
        VK_STRUCTURE_TYPE_PIPELINE_FRAGMENT_SHADING_RATE_STATE_CREATE_INFO_KHR =
            1000226001,

        // Provided by VK_KHR_fragment_shading_rate
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_SHADING_RATE_PROPERTIES_KHR =
            1000226002,

        // Provided by VK_KHR_fragment_shading_rate
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_SHADING_RATE_FEATURES_KHR = 1000226003,

        // Provided by VK_KHR_fragment_shading_rate
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_SHADING_RATE_KHR = 1000226004,

        // Provided by VK_AMD_shader_core_properties2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_CORE_PROPERTIES_2_AMD = 1000227000,

        // Provided by VK_AMD_device_coherent_memory
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COHERENT_MEMORY_FEATURES_AMD = 1000229000,

        // Provided by VK_EXT_shader_image_atomic_int64
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_IMAGE_ATOMIC_INT64_FEATURES_EXT =
            1000234000,

        // Provided by VK_EXT_memory_budget
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MEMORY_BUDGET_PROPERTIES_EXT = 1000237000,

        // Provided by VK_EXT_memory_priority
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MEMORY_PRIORITY_FEATURES_EXT = 1000238000,

        // Provided by VK_EXT_memory_priority
        VK_STRUCTURE_TYPE_MEMORY_PRIORITY_ALLOCATE_INFO_EXT = 1000238001,

        // Provided by VK_KHR_surface_protected_capabilities
        VK_STRUCTURE_TYPE_SURFACE_PROTECTED_CAPABILITIES_KHR = 1000239000,

        // Provided by VK_NV_dedicated_allocation_image_aliasing
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEDICATED_ALLOCATION_IMAGE_ALIASING_FEATURES_NV
            = 1000240000,

        // Provided by VK_EXT_buffer_device_address
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BUFFER_DEVICE_ADDRESS_FEATURES_EXT = 1000244000,

        // Provided by VK_EXT_buffer_device_address
        VK_STRUCTURE_TYPE_BUFFER_DEVICE_ADDRESS_CREATE_INFO_EXT = 1000244002,

        // Provided by VK_EXT_tooling_info
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TOOL_PROPERTIES_EXT = 1000245000,

        // Provided by VK_EXT_validation_features
        VK_STRUCTURE_TYPE_VALIDATION_FEATURES_EXT = 1000247000,

        // Provided by VK_KHR_present_wait
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PRESENT_WAIT_FEATURES_KHR = 1000248000,

        // Provided by VK_NV_cooperative_matrix
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COOPERATIVE_MATRIX_FEATURES_NV = 1000249000,

        // Provided by VK_NV_cooperative_matrix
        VK_STRUCTURE_TYPE_COOPERATIVE_MATRIX_PROPERTIES_NV = 1000249001,

        // Provided by VK_NV_cooperative_matrix
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COOPERATIVE_MATRIX_PROPERTIES_NV = 1000249002,

        // Provided by VK_NV_coverage_reduction_mode
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COVERAGE_REDUCTION_MODE_FEATURES_NV =
            1000250000,

        // Provided by VK_NV_coverage_reduction_mode
        VK_STRUCTURE_TYPE_PIPELINE_COVERAGE_REDUCTION_STATE_CREATE_INFO_NV = 1000250001,

        // Provided by VK_NV_coverage_reduction_mode
        VK_STRUCTURE_TYPE_FRAMEBUFFER_MIXED_SAMPLES_COMBINATION_NV = 1000250002,

        // Provided by VK_EXT_fragment_shader_interlock
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_SHADER_INTERLOCK_FEATURES_EXT =
            1000251000,

        // Provided by VK_EXT_ycbcr_image_arrays
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_YCBCR_IMAGE_ARRAYS_FEATURES_EXT = 1000252000,

        // Provided by VK_EXT_provoking_vertex
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROVOKING_VERTEX_FEATURES_EXT = 1000254000,

        // Provided by VK_EXT_provoking_vertex
        VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_PROVOKING_VERTEX_STATE_CREATE_INFO_EXT =
            1000254001,

        // Provided by VK_EXT_provoking_vertex
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROVOKING_VERTEX_PROPERTIES_EXT = 1000254002,

        // Provided by VK_EXT_full_screen_exclusive
        VK_STRUCTURE_TYPE_SURFACE_FULL_SCREEN_EXCLUSIVE_INFO_EXT = 1000255000,

        // Provided by VK_EXT_full_screen_exclusive
        VK_STRUCTURE_TYPE_SURFACE_CAPABILITIES_FULL_SCREEN_EXCLUSIVE_EXT = 1000255002,

        // Provided by VK_EXT_full_screen_exclusive with VK_KHR_win32_surface
        VK_STRUCTURE_TYPE_SURFACE_FULL_SCREEN_EXCLUSIVE_WIN32_INFO_EXT = 1000255001,

        // Provided by VK_EXT_headless_surface
        VK_STRUCTURE_TYPE_HEADLESS_SURFACE_CREATE_INFO_EXT = 1000256000,

        // Provided by VK_EXT_line_rasterization
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LINE_RASTERIZATION_FEATURES_EXT = 1000259000,

        // Provided by VK_EXT_line_rasterization
        VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_LINE_STATE_CREATE_INFO_EXT = 1000259001,

        // Provided by VK_EXT_line_rasterization
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LINE_RASTERIZATION_PROPERTIES_EXT = 1000259002,

        // Provided by VK_EXT_shader_atomic_float
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_ATOMIC_FLOAT_FEATURES_EXT = 1000260000,

        // Provided by VK_EXT_index_type_uint8
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INDEX_TYPE_UINT8_FEATURES_EXT = 1000265000,

        // Provided by VK_EXT_extended_dynamic_state
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTENDED_DYNAMIC_STATE_FEATURES_EXT =
            1000267000,

        // Provided by VK_KHR_pipeline_executable_properties
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_EXECUTABLE_PROPERTIES_FEATURES_KHR =
            1000269000,

        // Provided by VK_KHR_pipeline_executable_properties
        VK_STRUCTURE_TYPE_PIPELINE_INFO_KHR = 1000269001,

        // Provided by VK_KHR_pipeline_executable_properties
        VK_STRUCTURE_TYPE_PIPELINE_EXECUTABLE_PROPERTIES_KHR = 1000269002,

        // Provided by VK_KHR_pipeline_executable_properties
        VK_STRUCTURE_TYPE_PIPELINE_EXECUTABLE_INFO_KHR = 1000269003,

        // Provided by VK_KHR_pipeline_executable_properties
        VK_STRUCTURE_TYPE_PIPELINE_EXECUTABLE_STATISTIC_KHR = 1000269004,

        // Provided by VK_KHR_pipeline_executable_properties
        VK_STRUCTURE_TYPE_PIPELINE_EXECUTABLE_INTERNAL_REPRESENTATION_KHR = 1000269005,

        // Provided by VK_EXT_shader_atomic_float2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_ATOMIC_FLOAT_2_FEATURES_EXT = 1000273000,

        // Provided by VK_EXT_shader_demote_to_helper_invocation
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_DEMOTE_TO_HELPER_INVOCATION_FEATURES_EXT
            = 1000276000,

        // Provided by VK_NV_device_generated_commands
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEVICE_GENERATED_COMMANDS_PROPERTIES_NV =
            1000277000,

        // Provided by VK_NV_device_generated_commands
        VK_STRUCTURE_TYPE_GRAPHICS_SHADER_GROUP_CREATE_INFO_NV = 1000277001,

        // Provided by VK_NV_device_generated_commands
        VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_SHADER_GROUPS_CREATE_INFO_NV = 1000277002,

        // Provided by VK_NV_device_generated_commands
        VK_STRUCTURE_TYPE_INDIRECT_COMMANDS_LAYOUT_TOKEN_NV = 1000277003,

        // Provided by VK_NV_device_generated_commands
        VK_STRUCTURE_TYPE_INDIRECT_COMMANDS_LAYOUT_CREATE_INFO_NV = 1000277004,

        // Provided by VK_NV_device_generated_commands
        VK_STRUCTURE_TYPE_GENERATED_COMMANDS_INFO_NV = 1000277005,

        // Provided by VK_NV_device_generated_commands
        VK_STRUCTURE_TYPE_GENERATED_COMMANDS_MEMORY_REQUIREMENTS_INFO_NV = 1000277006,

        // Provided by VK_NV_device_generated_commands
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEVICE_GENERATED_COMMANDS_FEATURES_NV =
            1000277007,

        // Provided by VK_NV_inherited_viewport_scissor
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INHERITED_VIEWPORT_SCISSOR_FEATURES_NV =
            1000278000,

        // Provided by VK_NV_inherited_viewport_scissor
        VK_STRUCTURE_TYPE_COMMAND_BUFFER_INHERITANCE_VIEWPORT_SCISSOR_INFO_NV =
            1000278001,

        // Provided by VK_EXT_texel_buffer_alignment
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TEXEL_BUFFER_ALIGNMENT_FEATURES_EXT =
            1000281000,

        // Provided by VK_EXT_texel_buffer_alignment
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TEXEL_BUFFER_ALIGNMENT_PROPERTIES_EXT =
            1000281001,

        // Provided by VK_QCOM_render_pass_transform
        VK_STRUCTURE_TYPE_COMMAND_BUFFER_INHERITANCE_RENDER_PASS_TRANSFORM_INFO_QCOM =
            1000282000,

        // Provided by VK_QCOM_render_pass_transform
        VK_STRUCTURE_TYPE_RENDER_PASS_TRANSFORM_BEGIN_INFO_QCOM = 1000282001,

        // Provided by VK_EXT_device_memory_report
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEVICE_MEMORY_REPORT_FEATURES_EXT = 1000284000,

        // Provided by VK_EXT_device_memory_report
        VK_STRUCTURE_TYPE_DEVICE_DEVICE_MEMORY_REPORT_CREATE_INFO_EXT = 1000284001,

        // Provided by VK_EXT_device_memory_report
        VK_STRUCTURE_TYPE_DEVICE_MEMORY_REPORT_CALLBACK_DATA_EXT = 1000284002,

        // Provided by VK_EXT_robustness2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ROBUSTNESS_2_FEATURES_EXT = 1000286000,

        // Provided by VK_EXT_robustness2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ROBUSTNESS_2_PROPERTIES_EXT = 1000286001,

        // Provided by VK_EXT_custom_border_color
        VK_STRUCTURE_TYPE_SAMPLER_CUSTOM_BORDER_COLOR_CREATE_INFO_EXT = 1000287000,

        // Provided by VK_EXT_custom_border_color
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CUSTOM_BORDER_COLOR_PROPERTIES_EXT = 1000287001,

        // Provided by VK_EXT_custom_border_color
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CUSTOM_BORDER_COLOR_FEATURES_EXT = 1000287002,

        // Provided by VK_KHR_pipeline_library
        VK_STRUCTURE_TYPE_PIPELINE_LIBRARY_CREATE_INFO_KHR = 1000290000,

        // Provided by VK_KHR_present_id
        VK_STRUCTURE_TYPE_PRESENT_ID_KHR = 1000294000,

        // Provided by VK_KHR_present_id
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PRESENT_ID_FEATURES_KHR = 1000294001,

        // Provided by VK_EXT_private_data
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PRIVATE_DATA_FEATURES_EXT = 1000295000,

        // Provided by VK_EXT_private_data
        VK_STRUCTURE_TYPE_DEVICE_PRIVATE_DATA_CREATE_INFO_EXT = 1000295001,

        // Provided by VK_EXT_private_data
        VK_STRUCTURE_TYPE_PRIVATE_DATA_SLOT_CREATE_INFO_EXT = 1000295002,

        // Provided by VK_EXT_pipeline_creation_cache_control
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_CREATION_CACHE_CONTROL_FEATURES_EXT =
            1000297000,

        // Provided by VK_KHR_video_encode_queue
        VK_STRUCTURE_TYPE_VIDEO_ENCODE_INFO_KHR = 1000299000,

        // Provided by VK_KHR_video_encode_queue
        VK_STRUCTURE_TYPE_VIDEO_ENCODE_RATE_CONTROL_INFO_KHR = 1000299001,

        // Provided by VK_NV_device_diagnostics_config
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DIAGNOSTICS_CONFIG_FEATURES_NV = 1000300000,

        // Provided by VK_NV_device_diagnostics_config
        VK_STRUCTURE_TYPE_DEVICE_DIAGNOSTICS_CONFIG_CREATE_INFO_NV = 1000300001,

        // Provided by VK_KHR_synchronization2
        VK_STRUCTURE_TYPE_MEMORY_BARRIER_2_KHR = 1000314000,

        // Provided by VK_KHR_synchronization2
        VK_STRUCTURE_TYPE_BUFFER_MEMORY_BARRIER_2_KHR = 1000314001,

        // Provided by VK_KHR_synchronization2
        VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER_2_KHR = 1000314002,

        // Provided by VK_KHR_synchronization2
        VK_STRUCTURE_TYPE_DEPENDENCY_INFO_KHR = 1000314003,

        // Provided by VK_KHR_synchronization2
        VK_STRUCTURE_TYPE_SUBMIT_INFO_2_KHR = 1000314004,

        // Provided by VK_KHR_synchronization2
        VK_STRUCTURE_TYPE_SEMAPHORE_SUBMIT_INFO_KHR = 1000314005,

        // Provided by VK_KHR_synchronization2
        VK_STRUCTURE_TYPE_COMMAND_BUFFER_SUBMIT_INFO_KHR = 1000314006,

        // Provided by VK_KHR_synchronization2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SYNCHRONIZATION_2_FEATURES_KHR = 1000314007,

        // Provided by VK_KHR_synchronization2 with VK_NV_device_diagnostic_checkpoints
        VK_STRUCTURE_TYPE_QUEUE_FAMILY_CHECKPOINT_PROPERTIES_2_NV = 1000314008,

        // Provided by VK_KHR_synchronization2 with VK_NV_device_diagnostic_checkpoints
        VK_STRUCTURE_TYPE_CHECKPOINT_DATA_2_NV = 1000314009,

        // Provided by VK_KHR_shader_subgroup_uniform_control_flow
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_SUBGROUP_UNIFORM_CONTROL_FLOW_FEATURES_KHR
            = 1000323000,

        // Provided by VK_KHR_zero_initialize_workgroup_memory
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ZERO_INITIALIZE_WORKGROUP_MEMORY_FEATURES_KHR =
            1000325000,

        // Provided by VK_NV_fragment_shading_rate_enums
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_SHADING_RATE_ENUMS_PROPERTIES_NV =
            1000326000,

        // Provided by VK_NV_fragment_shading_rate_enums
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_SHADING_RATE_ENUMS_FEATURES_NV =
            1000326001,

        // Provided by VK_NV_fragment_shading_rate_enums
        VK_STRUCTURE_TYPE_PIPELINE_FRAGMENT_SHADING_RATE_ENUM_STATE_CREATE_INFO_NV =
            1000326002,

        // Provided by VK_NV_ray_tracing_motion_blur
        VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_GEOMETRY_MOTION_TRIANGLES_DATA_NV =
            1000327000,

        // Provided by VK_NV_ray_tracing_motion_blur
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RAY_TRACING_MOTION_BLUR_FEATURES_NV =
            1000327001,

        // Provided by VK_NV_ray_tracing_motion_blur
        VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_MOTION_INFO_NV = 1000327002,

        // Provided by VK_EXT_ycbcr_2plane_444_formats
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_YCBCR_2_PLANE_444_FORMATS_FEATURES_EXT =
            1000330000,

        // Provided by VK_EXT_fragment_density_map2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_DENSITY_MAP_2_FEATURES_EXT =
            1000332000,

        // Provided by VK_EXT_fragment_density_map2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_DENSITY_MAP_2_PROPERTIES_EXT =
            1000332001,

        // Provided by VK_QCOM_rotated_copy_commands
        VK_STRUCTURE_TYPE_COPY_COMMAND_TRANSFORM_INFO_QCOM = 1000333000,

        // Provided by VK_EXT_image_robustness
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_ROBUSTNESS_FEATURES_EXT = 1000335000,

        // Provided by VK_KHR_workgroup_memory_explicit_layout
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_WORKGROUP_MEMORY_EXPLICIT_LAYOUT_FEATURES_KHR =
            1000336000,

        // Provided by VK_KHR_copy_commands2
        VK_STRUCTURE_TYPE_COPY_BUFFER_INFO_2_KHR = 1000337000,

        // Provided by VK_KHR_copy_commands2
        VK_STRUCTURE_TYPE_COPY_IMAGE_INFO_2_KHR = 1000337001,

        // Provided by VK_KHR_copy_commands2
        VK_STRUCTURE_TYPE_COPY_BUFFER_TO_IMAGE_INFO_2_KHR = 1000337002,

        // Provided by VK_KHR_copy_commands2
        VK_STRUCTURE_TYPE_COPY_IMAGE_TO_BUFFER_INFO_2_KHR = 1000337003,

        // Provided by VK_KHR_copy_commands2
        VK_STRUCTURE_TYPE_BLIT_IMAGE_INFO_2_KHR = 1000337004,

        // Provided by VK_KHR_copy_commands2
        VK_STRUCTURE_TYPE_RESOLVE_IMAGE_INFO_2_KHR = 1000337005,

        // Provided by VK_KHR_copy_commands2
        VK_STRUCTURE_TYPE_BUFFER_COPY_2_KHR = 1000337006,

        // Provided by VK_KHR_copy_commands2
        VK_STRUCTURE_TYPE_IMAGE_COPY_2_KHR = 1000337007,

        // Provided by VK_KHR_copy_commands2
        VK_STRUCTURE_TYPE_IMAGE_BLIT_2_KHR = 1000337008,

        // Provided by VK_KHR_copy_commands2
        VK_STRUCTURE_TYPE_BUFFER_IMAGE_COPY_2_KHR = 1000337009,

        // Provided by VK_KHR_copy_commands2
        VK_STRUCTURE_TYPE_IMAGE_RESOLVE_2_KHR = 1000337010,

        // Provided by VK_EXT_4444_formats
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_4444_FORMATS_FEATURES_EXT = 1000340000,

        // Provided by VK_EXT_directfb_surface
        VK_STRUCTURE_TYPE_DIRECTFB_SURFACE_CREATE_INFO_EXT = 1000346000,

        // Provided by VK_VALVE_mutable_descriptor_type
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MUTABLE_DESCRIPTOR_TYPE_FEATURES_VALVE =
            1000351000,

        // Provided by VK_VALVE_mutable_descriptor_type
        VK_STRUCTURE_TYPE_MUTABLE_DESCRIPTOR_TYPE_CREATE_INFO_VALVE = 1000351002,

        // Provided by VK_EXT_vertex_input_dynamic_state
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VERTEX_INPUT_DYNAMIC_STATE_FEATURES_EXT =
            1000352000,

        // Provided by VK_EXT_vertex_input_dynamic_state
        VK_STRUCTURE_TYPE_VERTEX_INPUT_BINDING_DESCRIPTION_2_EXT = 1000352001,

        // Provided by VK_EXT_vertex_input_dynamic_state
        VK_STRUCTURE_TYPE_VERTEX_INPUT_ATTRIBUTE_DESCRIPTION_2_EXT = 1000352002,

        // Provided by VK_EXT_physical_device_drm
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DRM_PROPERTIES_EXT = 1000353000,

        // Provided by VK_FUCHSIA_external_memory
        VK_STRUCTURE_TYPE_IMPORT_MEMORY_ZIRCON_HANDLE_INFO_FUCHSIA = 1000364000,

        // Provided by VK_FUCHSIA_external_memory
        VK_STRUCTURE_TYPE_MEMORY_ZIRCON_HANDLE_PROPERTIES_FUCHSIA = 1000364001,

        // Provided by VK_FUCHSIA_external_memory
        VK_STRUCTURE_TYPE_MEMORY_GET_ZIRCON_HANDLE_INFO_FUCHSIA = 1000364002,

        // Provided by VK_FUCHSIA_external_semaphore
        VK_STRUCTURE_TYPE_IMPORT_SEMAPHORE_ZIRCON_HANDLE_INFO_FUCHSIA = 1000365000,

        // Provided by VK_FUCHSIA_external_semaphore
        VK_STRUCTURE_TYPE_SEMAPHORE_GET_ZIRCON_HANDLE_INFO_FUCHSIA = 1000365001,

        // Provided by VK_HUAWEI_subpass_shading
        VK_STRUCTURE_TYPE_SUBPASS_SHADING_PIPELINE_CREATE_INFO_HUAWEI = 1000369000,

        // Provided by VK_HUAWEI_subpass_shading
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SUBPASS_SHADING_FEATURES_HUAWEI = 1000369001,

        // Provided by VK_HUAWEI_subpass_shading
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SUBPASS_SHADING_PROPERTIES_HUAWEI = 1000369002,

        // Provided by VK_HUAWEI_invocation_mask
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INVOCATION_MASK_FEATURES_HUAWEI = 1000370000,

        // Provided by VK_NV_external_memory_rdma
        VK_STRUCTURE_TYPE_MEMORY_GET_REMOTE_ADDRESS_INFO_NV = 1000371000,

        // Provided by VK_NV_external_memory_rdma
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_MEMORY_RDMA_FEATURES_NV = 1000371001,

        // Provided by VK_EXT_extended_dynamic_state2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTENDED_DYNAMIC_STATE_2_FEATURES_EXT =
            1000377000,

        // Provided by VK_QNX_screen_surface
        VK_STRUCTURE_TYPE_SCREEN_SURFACE_CREATE_INFO_QNX = 1000378000,

        // Provided by VK_EXT_color_write_enable
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COLOR_WRITE_ENABLE_FEATURES_EXT = 1000381000,

        // Provided by VK_EXT_color_write_enable
        VK_STRUCTURE_TYPE_PIPELINE_COLOR_WRITE_CREATE_INFO_EXT = 1000381001,

        // Provided by VK_EXT_global_priority_query
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_GLOBAL_PRIORITY_QUERY_FEATURES_EXT = 1000388000,

        // Provided by VK_EXT_global_priority_query
        VK_STRUCTURE_TYPE_QUEUE_FAMILY_GLOBAL_PRIORITY_PROPERTIES_EXT = 1000388001,

        // Provided by VK_EXT_multi_draw
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTI_DRAW_FEATURES_EXT = 1000392000,

        // Provided by VK_EXT_multi_draw
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTI_DRAW_PROPERTIES_EXT = 1000392001,

        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTER_FEATURES =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTERS_FEATURES,

        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_DRAW_PARAMETER_FEATURES =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_DRAW_PARAMETERS_FEATURES,

        VK_STRUCTURE_TYPE_DEBUG_REPORT_CREATE_INFO_EXT =
            VK_STRUCTURE_TYPE_DEBUG_REPORT_CALLBACK_CREATE_INFO_EXT,

        // Provided by VK_KHR_multiview
        VK_STRUCTURE_TYPE_RENDER_PASS_MULTIVIEW_CREATE_INFO_KHR =
            VK_STRUCTURE_TYPE_RENDER_PASS_MULTIVIEW_CREATE_INFO,

        // Provided by VK_KHR_multiview
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_FEATURES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_FEATURES,

        // Provided by VK_KHR_multiview
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_PROPERTIES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_PROPERTIES,

        // Provided by VK_KHR_get_physical_device_properties2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FEATURES_2_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FEATURES_2,

        // Provided by VK_KHR_get_physical_device_properties2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROPERTIES_2_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROPERTIES_2,

        // Provided by VK_KHR_get_physical_device_properties2
        VK_STRUCTURE_TYPE_FORMAT_PROPERTIES_2_KHR = VK_STRUCTURE_TYPE_FORMAT_PROPERTIES_2,

        // Provided by VK_KHR_get_physical_device_properties2
        VK_STRUCTURE_TYPE_IMAGE_FORMAT_PROPERTIES_2_KHR =
            VK_STRUCTURE_TYPE_IMAGE_FORMAT_PROPERTIES_2,

        // Provided by VK_KHR_get_physical_device_properties2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_FORMAT_INFO_2_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_FORMAT_INFO_2,

        // Provided by VK_KHR_get_physical_device_properties2
        VK_STRUCTURE_TYPE_QUEUE_FAMILY_PROPERTIES_2_KHR =
            VK_STRUCTURE_TYPE_QUEUE_FAMILY_PROPERTIES_2,

        // Provided by VK_KHR_get_physical_device_properties2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MEMORY_PROPERTIES_2_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MEMORY_PROPERTIES_2,

        // Provided by VK_KHR_get_physical_device_properties2
        VK_STRUCTURE_TYPE_SPARSE_IMAGE_FORMAT_PROPERTIES_2_KHR =
            VK_STRUCTURE_TYPE_SPARSE_IMAGE_FORMAT_PROPERTIES_2,

        // Provided by VK_KHR_get_physical_device_properties2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SPARSE_IMAGE_FORMAT_INFO_2_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SPARSE_IMAGE_FORMAT_INFO_2,

        // Provided by VK_KHR_device_group
        VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_FLAGS_INFO_KHR =
            VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_FLAGS_INFO,

        // Provided by VK_KHR_device_group
        VK_STRUCTURE_TYPE_DEVICE_GROUP_RENDER_PASS_BEGIN_INFO_KHR =
            VK_STRUCTURE_TYPE_DEVICE_GROUP_RENDER_PASS_BEGIN_INFO,

        // Provided by VK_KHR_device_group
        VK_STRUCTURE_TYPE_DEVICE_GROUP_COMMAND_BUFFER_BEGIN_INFO_KHR =
            VK_STRUCTURE_TYPE_DEVICE_GROUP_COMMAND_BUFFER_BEGIN_INFO,

        // Provided by VK_KHR_device_group
        VK_STRUCTURE_TYPE_DEVICE_GROUP_SUBMIT_INFO_KHR =
            VK_STRUCTURE_TYPE_DEVICE_GROUP_SUBMIT_INFO,

        // Provided by VK_KHR_device_group
        VK_STRUCTURE_TYPE_DEVICE_GROUP_BIND_SPARSE_INFO_KHR =
            VK_STRUCTURE_TYPE_DEVICE_GROUP_BIND_SPARSE_INFO,

        // Provided by VK_KHR_device_group with VK_KHR_bind_memory2
        VK_STRUCTURE_TYPE_BIND_BUFFER_MEMORY_DEVICE_GROUP_INFO_KHR =
            VK_STRUCTURE_TYPE_BIND_BUFFER_MEMORY_DEVICE_GROUP_INFO,

        // Provided by VK_KHR_device_group with VK_KHR_bind_memory2
        VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_DEVICE_GROUP_INFO_KHR =
            VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_DEVICE_GROUP_INFO,

        // Provided by VK_KHR_device_group_creation
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_GROUP_PROPERTIES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_GROUP_PROPERTIES,

        // Provided by VK_KHR_device_group_creation
        VK_STRUCTURE_TYPE_DEVICE_GROUP_DEVICE_CREATE_INFO_KHR =
            VK_STRUCTURE_TYPE_DEVICE_GROUP_DEVICE_CREATE_INFO,

        // Provided by VK_KHR_external_memory_capabilities
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_IMAGE_FORMAT_INFO_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_IMAGE_FORMAT_INFO,

        // Provided by VK_KHR_external_memory_capabilities
        VK_STRUCTURE_TYPE_EXTERNAL_IMAGE_FORMAT_PROPERTIES_KHR =
            VK_STRUCTURE_TYPE_EXTERNAL_IMAGE_FORMAT_PROPERTIES,

        // Provided by VK_KHR_external_memory_capabilities
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_BUFFER_INFO_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_BUFFER_INFO,

        // Provided by VK_KHR_external_memory_capabilities
        VK_STRUCTURE_TYPE_EXTERNAL_BUFFER_PROPERTIES_KHR =
            VK_STRUCTURE_TYPE_EXTERNAL_BUFFER_PROPERTIES,

        // Provided by VK_KHR_external_memory_capabilities, VK_KHR_external_semaphore_capabilities, VK_KHR_external_fence_capabilities
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ID_PROPERTIES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ID_PROPERTIES,

        // Provided by VK_KHR_external_memory
        VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_BUFFER_CREATE_INFO_KHR =
            VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_BUFFER_CREATE_INFO,

        // Provided by VK_KHR_external_memory
        VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_IMAGE_CREATE_INFO_KHR =
            VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_IMAGE_CREATE_INFO,

        // Provided by VK_KHR_external_memory
        VK_STRUCTURE_TYPE_EXPORT_MEMORY_ALLOCATE_INFO_KHR =
            VK_STRUCTURE_TYPE_EXPORT_MEMORY_ALLOCATE_INFO,

        // Provided by VK_KHR_external_semaphore_capabilities
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_SEMAPHORE_INFO_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_SEMAPHORE_INFO,

        // Provided by VK_KHR_external_semaphore_capabilities
        VK_STRUCTURE_TYPE_EXTERNAL_SEMAPHORE_PROPERTIES_KHR =
            VK_STRUCTURE_TYPE_EXTERNAL_SEMAPHORE_PROPERTIES,

        // Provided by VK_KHR_external_semaphore
        VK_STRUCTURE_TYPE_EXPORT_SEMAPHORE_CREATE_INFO_KHR =
            VK_STRUCTURE_TYPE_EXPORT_SEMAPHORE_CREATE_INFO,

        // Provided by VK_KHR_shader_float16_int8
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_FLOAT16_INT8_FEATURES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_FLOAT16_INT8_FEATURES,

        // Provided by VK_KHR_shader_float16_int8
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FLOAT16_INT8_FEATURES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_FLOAT16_INT8_FEATURES,

        // Provided by VK_KHR_16bit_storage
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_16BIT_STORAGE_FEATURES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_16BIT_STORAGE_FEATURES,

        // Provided by VK_KHR_descriptor_update_template
        VK_STRUCTURE_TYPE_DESCRIPTOR_UPDATE_TEMPLATE_CREATE_INFO_KHR =
            VK_STRUCTURE_TYPE_DESCRIPTOR_UPDATE_TEMPLATE_CREATE_INFO,

        VK_STRUCTURE_TYPE_SURFACE_CAPABILITIES2_EXT =
            VK_STRUCTURE_TYPE_SURFACE_CAPABILITIES_2_EXT,

        // Provided by VK_KHR_imageless_framebuffer
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGELESS_FRAMEBUFFER_FEATURES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGELESS_FRAMEBUFFER_FEATURES,

        // Provided by VK_KHR_imageless_framebuffer
        VK_STRUCTURE_TYPE_FRAMEBUFFER_ATTACHMENTS_CREATE_INFO_KHR =
            VK_STRUCTURE_TYPE_FRAMEBUFFER_ATTACHMENTS_CREATE_INFO,

        // Provided by VK_KHR_imageless_framebuffer
        VK_STRUCTURE_TYPE_FRAMEBUFFER_ATTACHMENT_IMAGE_INFO_KHR =
            VK_STRUCTURE_TYPE_FRAMEBUFFER_ATTACHMENT_IMAGE_INFO,

        // Provided by VK_KHR_imageless_framebuffer
        VK_STRUCTURE_TYPE_RENDER_PASS_ATTACHMENT_BEGIN_INFO_KHR =
            VK_STRUCTURE_TYPE_RENDER_PASS_ATTACHMENT_BEGIN_INFO,

        // Provided by VK_KHR_create_renderpass2
        VK_STRUCTURE_TYPE_ATTACHMENT_DESCRIPTION_2_KHR =
            VK_STRUCTURE_TYPE_ATTACHMENT_DESCRIPTION_2,

        // Provided by VK_KHR_create_renderpass2
        VK_STRUCTURE_TYPE_ATTACHMENT_REFERENCE_2_KHR =
            VK_STRUCTURE_TYPE_ATTACHMENT_REFERENCE_2,

        // Provided by VK_KHR_create_renderpass2
        VK_STRUCTURE_TYPE_SUBPASS_DESCRIPTION_2_KHR =
            VK_STRUCTURE_TYPE_SUBPASS_DESCRIPTION_2,

        // Provided by VK_KHR_create_renderpass2
        VK_STRUCTURE_TYPE_SUBPASS_DEPENDENCY_2_KHR =
            VK_STRUCTURE_TYPE_SUBPASS_DEPENDENCY_2,

        // Provided by VK_KHR_create_renderpass2
        VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO_2_KHR =
            VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO_2,

        // Provided by VK_KHR_create_renderpass2
        VK_STRUCTURE_TYPE_SUBPASS_BEGIN_INFO_KHR = VK_STRUCTURE_TYPE_SUBPASS_BEGIN_INFO,

        // Provided by VK_KHR_create_renderpass2
        VK_STRUCTURE_TYPE_SUBPASS_END_INFO_KHR = VK_STRUCTURE_TYPE_SUBPASS_END_INFO,

        // Provided by VK_KHR_external_fence_capabilities
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_FENCE_INFO_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_FENCE_INFO,

        // Provided by VK_KHR_external_fence_capabilities
        VK_STRUCTURE_TYPE_EXTERNAL_FENCE_PROPERTIES_KHR =
            VK_STRUCTURE_TYPE_EXTERNAL_FENCE_PROPERTIES,

        // Provided by VK_KHR_external_fence
        VK_STRUCTURE_TYPE_EXPORT_FENCE_CREATE_INFO_KHR =
            VK_STRUCTURE_TYPE_EXPORT_FENCE_CREATE_INFO,

        // Provided by VK_KHR_maintenance2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_POINT_CLIPPING_PROPERTIES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_POINT_CLIPPING_PROPERTIES,

        // Provided by VK_KHR_maintenance2
        VK_STRUCTURE_TYPE_RENDER_PASS_INPUT_ATTACHMENT_ASPECT_CREATE_INFO_KHR =
            VK_STRUCTURE_TYPE_RENDER_PASS_INPUT_ATTACHMENT_ASPECT_CREATE_INFO,

        // Provided by VK_KHR_maintenance2
        VK_STRUCTURE_TYPE_IMAGE_VIEW_USAGE_CREATE_INFO_KHR =
            VK_STRUCTURE_TYPE_IMAGE_VIEW_USAGE_CREATE_INFO,

        // Provided by VK_KHR_maintenance2
        VK_STRUCTURE_TYPE_PIPELINE_TESSELLATION_DOMAIN_ORIGIN_STATE_CREATE_INFO_KHR =
            VK_STRUCTURE_TYPE_PIPELINE_TESSELLATION_DOMAIN_ORIGIN_STATE_CREATE_INFO,

        // Provided by VK_KHR_variable_pointers
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTERS_FEATURES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTERS_FEATURES,

        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTER_FEATURES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTERS_FEATURES_KHR,

        // Provided by VK_KHR_dedicated_allocation
        VK_STRUCTURE_TYPE_MEMORY_DEDICATED_REQUIREMENTS_KHR =
            VK_STRUCTURE_TYPE_MEMORY_DEDICATED_REQUIREMENTS,

        // Provided by VK_KHR_dedicated_allocation
        VK_STRUCTURE_TYPE_MEMORY_DEDICATED_ALLOCATE_INFO_KHR =
            VK_STRUCTURE_TYPE_MEMORY_DEDICATED_ALLOCATE_INFO,

        // Provided by VK_EXT_sampler_filter_minmax
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLER_FILTER_MINMAX_PROPERTIES_EXT =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLER_FILTER_MINMAX_PROPERTIES,

        // Provided by VK_EXT_sampler_filter_minmax
        VK_STRUCTURE_TYPE_SAMPLER_REDUCTION_MODE_CREATE_INFO_EXT =
            VK_STRUCTURE_TYPE_SAMPLER_REDUCTION_MODE_CREATE_INFO,

        // Provided by VK_KHR_get_memory_requirements2
        VK_STRUCTURE_TYPE_BUFFER_MEMORY_REQUIREMENTS_INFO_2_KHR =
            VK_STRUCTURE_TYPE_BUFFER_MEMORY_REQUIREMENTS_INFO_2,

        // Provided by VK_KHR_get_memory_requirements2
        VK_STRUCTURE_TYPE_IMAGE_MEMORY_REQUIREMENTS_INFO_2_KHR =
            VK_STRUCTURE_TYPE_IMAGE_MEMORY_REQUIREMENTS_INFO_2,

        // Provided by VK_KHR_get_memory_requirements2
        VK_STRUCTURE_TYPE_IMAGE_SPARSE_MEMORY_REQUIREMENTS_INFO_2_KHR =
            VK_STRUCTURE_TYPE_IMAGE_SPARSE_MEMORY_REQUIREMENTS_INFO_2,

        // Provided by VK_KHR_get_memory_requirements2
        VK_STRUCTURE_TYPE_MEMORY_REQUIREMENTS_2_KHR =
            VK_STRUCTURE_TYPE_MEMORY_REQUIREMENTS_2,

        // Provided by VK_KHR_get_memory_requirements2
        VK_STRUCTURE_TYPE_SPARSE_IMAGE_MEMORY_REQUIREMENTS_2_KHR =
            VK_STRUCTURE_TYPE_SPARSE_IMAGE_MEMORY_REQUIREMENTS_2,

        // Provided by VK_KHR_image_format_list
        VK_STRUCTURE_TYPE_IMAGE_FORMAT_LIST_CREATE_INFO_KHR =
            VK_STRUCTURE_TYPE_IMAGE_FORMAT_LIST_CREATE_INFO,

        // Provided by VK_KHR_sampler_ycbcr_conversion
        VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_CREATE_INFO_KHR =
            VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_CREATE_INFO,

        // Provided by VK_KHR_sampler_ycbcr_conversion
        VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_INFO_KHR =
            VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_INFO,

        // Provided by VK_KHR_sampler_ycbcr_conversion
        VK_STRUCTURE_TYPE_BIND_IMAGE_PLANE_MEMORY_INFO_KHR =
            VK_STRUCTURE_TYPE_BIND_IMAGE_PLANE_MEMORY_INFO,

        // Provided by VK_KHR_sampler_ycbcr_conversion
        VK_STRUCTURE_TYPE_IMAGE_PLANE_MEMORY_REQUIREMENTS_INFO_KHR =
            VK_STRUCTURE_TYPE_IMAGE_PLANE_MEMORY_REQUIREMENTS_INFO,

        // Provided by VK_KHR_sampler_ycbcr_conversion
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLER_YCBCR_CONVERSION_FEATURES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLER_YCBCR_CONVERSION_FEATURES,

        // Provided by VK_KHR_sampler_ycbcr_conversion
        VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_IMAGE_FORMAT_PROPERTIES_KHR =
            VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_IMAGE_FORMAT_PROPERTIES,

        // Provided by VK_KHR_bind_memory2
        VK_STRUCTURE_TYPE_BIND_BUFFER_MEMORY_INFO_KHR =
            VK_STRUCTURE_TYPE_BIND_BUFFER_MEMORY_INFO,

        // Provided by VK_KHR_bind_memory2
        VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_INFO_KHR =
            VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_INFO,

        // Provided by VK_EXT_descriptor_indexing
        VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_BINDING_FLAGS_CREATE_INFO_EXT =
            VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_BINDING_FLAGS_CREATE_INFO,

        // Provided by VK_EXT_descriptor_indexing
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_INDEXING_FEATURES_EXT =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_INDEXING_FEATURES,

        // Provided by VK_EXT_descriptor_indexing
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_INDEXING_PROPERTIES_EXT =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_INDEXING_PROPERTIES,

        // Provided by VK_EXT_descriptor_indexing
        VK_STRUCTURE_TYPE_DESCRIPTOR_SET_VARIABLE_DESCRIPTOR_COUNT_ALLOCATE_INFO_EXT =
            VK_STRUCTURE_TYPE_DESCRIPTOR_SET_VARIABLE_DESCRIPTOR_COUNT_ALLOCATE_INFO,

        // Provided by VK_EXT_descriptor_indexing
        VK_STRUCTURE_TYPE_DESCRIPTOR_SET_VARIABLE_DESCRIPTOR_COUNT_LAYOUT_SUPPORT_EXT =
            VK_STRUCTURE_TYPE_DESCRIPTOR_SET_VARIABLE_DESCRIPTOR_COUNT_LAYOUT_SUPPORT,

        // Provided by VK_KHR_maintenance3
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_3_PROPERTIES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_3_PROPERTIES,

        // Provided by VK_KHR_maintenance3
        VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_SUPPORT_KHR =
            VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_SUPPORT,

        // Provided by VK_KHR_shader_subgroup_extended_types
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_SUBGROUP_EXTENDED_TYPES_FEATURES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_SUBGROUP_EXTENDED_TYPES_FEATURES,

        // Provided by VK_KHR_8bit_storage
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_8BIT_STORAGE_FEATURES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_8BIT_STORAGE_FEATURES,

        // Provided by VK_KHR_shader_atomic_int64
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_ATOMIC_INT64_FEATURES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_ATOMIC_INT64_FEATURES,

        // Provided by VK_KHR_driver_properties
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DRIVER_PROPERTIES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DRIVER_PROPERTIES,

        // Provided by VK_KHR_shader_float_controls
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FLOAT_CONTROLS_PROPERTIES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FLOAT_CONTROLS_PROPERTIES,

        // Provided by VK_KHR_depth_stencil_resolve
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEPTH_STENCIL_RESOLVE_PROPERTIES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEPTH_STENCIL_RESOLVE_PROPERTIES,

        // Provided by VK_KHR_depth_stencil_resolve
        VK_STRUCTURE_TYPE_SUBPASS_DESCRIPTION_DEPTH_STENCIL_RESOLVE_KHR =
            VK_STRUCTURE_TYPE_SUBPASS_DESCRIPTION_DEPTH_STENCIL_RESOLVE,

        // Provided by VK_KHR_timeline_semaphore
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TIMELINE_SEMAPHORE_FEATURES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TIMELINE_SEMAPHORE_FEATURES,

        // Provided by VK_KHR_timeline_semaphore
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TIMELINE_SEMAPHORE_PROPERTIES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TIMELINE_SEMAPHORE_PROPERTIES,

        // Provided by VK_KHR_timeline_semaphore
        VK_STRUCTURE_TYPE_SEMAPHORE_TYPE_CREATE_INFO_KHR =
            VK_STRUCTURE_TYPE_SEMAPHORE_TYPE_CREATE_INFO,

        // Provided by VK_KHR_timeline_semaphore
        VK_STRUCTURE_TYPE_TIMELINE_SEMAPHORE_SUBMIT_INFO_KHR =
            VK_STRUCTURE_TYPE_TIMELINE_SEMAPHORE_SUBMIT_INFO,

        // Provided by VK_KHR_timeline_semaphore
        VK_STRUCTURE_TYPE_SEMAPHORE_WAIT_INFO_KHR = VK_STRUCTURE_TYPE_SEMAPHORE_WAIT_INFO,

        // Provided by VK_KHR_timeline_semaphore
        VK_STRUCTURE_TYPE_SEMAPHORE_SIGNAL_INFO_KHR =
            VK_STRUCTURE_TYPE_SEMAPHORE_SIGNAL_INFO,

        VK_STRUCTURE_TYPE_QUERY_POOL_CREATE_INFO_INTEL =
            VK_STRUCTURE_TYPE_QUERY_POOL_PERFORMANCE_QUERY_CREATE_INFO_INTEL,

        // Provided by VK_KHR_vulkan_memory_model
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_MEMORY_MODEL_FEATURES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_MEMORY_MODEL_FEATURES,

        // Provided by VK_EXT_scalar_block_layout
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SCALAR_BLOCK_LAYOUT_FEATURES_EXT =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SCALAR_BLOCK_LAYOUT_FEATURES,

        // Provided by VK_KHR_separate_depth_stencil_layouts
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SEPARATE_DEPTH_STENCIL_LAYOUTS_FEATURES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SEPARATE_DEPTH_STENCIL_LAYOUTS_FEATURES,

        // Provided by VK_KHR_separate_depth_stencil_layouts
        VK_STRUCTURE_TYPE_ATTACHMENT_REFERENCE_STENCIL_LAYOUT_KHR =
            VK_STRUCTURE_TYPE_ATTACHMENT_REFERENCE_STENCIL_LAYOUT,

        // Provided by VK_KHR_separate_depth_stencil_layouts
        VK_STRUCTURE_TYPE_ATTACHMENT_DESCRIPTION_STENCIL_LAYOUT_KHR =
            VK_STRUCTURE_TYPE_ATTACHMENT_DESCRIPTION_STENCIL_LAYOUT,

        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BUFFER_ADDRESS_FEATURES_EXT =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BUFFER_DEVICE_ADDRESS_FEATURES_EXT,

        // Provided by VK_EXT_buffer_device_address
        VK_STRUCTURE_TYPE_BUFFER_DEVICE_ADDRESS_INFO_EXT =
            VK_STRUCTURE_TYPE_BUFFER_DEVICE_ADDRESS_INFO,

        // Provided by VK_EXT_separate_stencil_usage
        VK_STRUCTURE_TYPE_IMAGE_STENCIL_USAGE_CREATE_INFO_EXT =
            VK_STRUCTURE_TYPE_IMAGE_STENCIL_USAGE_CREATE_INFO,

        // Provided by VK_KHR_uniform_buffer_standard_layout
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_UNIFORM_BUFFER_STANDARD_LAYOUT_FEATURES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_UNIFORM_BUFFER_STANDARD_LAYOUT_FEATURES,

        // Provided by VK_KHR_buffer_device_address
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BUFFER_DEVICE_ADDRESS_FEATURES_KHR =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BUFFER_DEVICE_ADDRESS_FEATURES,

        // Provided by VK_KHR_buffer_device_address
        VK_STRUCTURE_TYPE_BUFFER_DEVICE_ADDRESS_INFO_KHR =
            VK_STRUCTURE_TYPE_BUFFER_DEVICE_ADDRESS_INFO,

        // Provided by VK_KHR_buffer_device_address
        VK_STRUCTURE_TYPE_BUFFER_OPAQUE_CAPTURE_ADDRESS_CREATE_INFO_KHR =
            VK_STRUCTURE_TYPE_BUFFER_OPAQUE_CAPTURE_ADDRESS_CREATE_INFO,

        // Provided by VK_KHR_buffer_device_address
        VK_STRUCTURE_TYPE_MEMORY_OPAQUE_CAPTURE_ADDRESS_ALLOCATE_INFO_KHR =
            VK_STRUCTURE_TYPE_MEMORY_OPAQUE_CAPTURE_ADDRESS_ALLOCATE_INFO,

        // Provided by VK_KHR_buffer_device_address
        VK_STRUCTURE_TYPE_DEVICE_MEMORY_OPAQUE_CAPTURE_ADDRESS_INFO_KHR =
            VK_STRUCTURE_TYPE_DEVICE_MEMORY_OPAQUE_CAPTURE_ADDRESS_INFO,

        // Provided by VK_EXT_host_query_reset
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_HOST_QUERY_RESET_FEATURES_EXT =
            VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_HOST_QUERY_RESET_FEATURES,
    }
}
