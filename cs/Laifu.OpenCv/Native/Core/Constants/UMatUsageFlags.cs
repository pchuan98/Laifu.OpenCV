// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Laifu.OpenCv.Native.Core.Constants;

/// <summary>
/// Usage flags for allocator
/// </summary>
/// <remarks>
/// <para>All flags except <see cref="USAGE_DEFAULT"/> are experimental.</para>
/// <para>
/// For the OpenCL allocator, <see cref="USAGE_ALLOCATE_SHARED_MEMORY"/> depends on
/// OpenCV's optional, experimental integration with OpenCL SVM. To enable this
/// integration, build OpenCV using the `WITH_OPENCL_SVM=ON` CMake option and, at
/// runtime, call `cv::ocl::Context::getDefault().setUseSVM(true);` or similar
/// code. Note that SVM is incompatible with OpenCL 1.x.
/// </para>
/// </remarks>
public enum UMatUsageFlags
{
    /// <summary>
    /// Default usage flag
    /// </summary>
    USAGE_DEFAULT = 0,

    /// <summary>
    /// Allocate host memory (platform and usage specific)
    /// </summary>
    USAGE_ALLOCATE_HOST_MEMORY = 1 << 0,

    /// <summary>
    /// Allocate device memory (platform and usage specific)
    /// </summary>
    USAGE_ALLOCATE_DEVICE_MEMORY = 1 << 1,

    /// <summary>
    /// Allocate shared memory (not equal to: USAGE_ALLOCATE_HOST_MEMORY | USAGE_ALLOCATE_DEVICE_MEMORY)
    /// </summary>
    USAGE_ALLOCATE_SHARED_MEMORY = 1 << 2,

    /// <summary>
    /// Binary compatibility hint
    /// </summary>
    __UMAT_USAGE_FLAGS_32BIT = 0x7fffffff
}
