// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Constants;

/// <summary>
/// Usage flags for allocator
///
/// Warning: All flags except `USAGE_DEFAULT` are experimental.
///
/// Warning: For the OpenCL allocator, `USAGE_ALLOCATE_SHARED_MEMORY` depends on
/// OpenCV's optional, experimental integration with OpenCL SVM. To enable this
/// integration, build OpenCV using the `WITH_OPENCL_SVM=ON` CMake option and, at
/// runtime, call `cv::ocl::Context::getDefault().setUseSVM(true);` or similar
/// code. Note that SVM is incompatible with OpenCL 1.x.
/// </summary>
[Flags]
public enum UMatUsageFlags
{
    /// <summary>
    /// Default usage
    /// </summary>
    DEFAULT = 0,

    /// <summary>
    /// Buffer allocation policy is platform and usage specific
    /// </summary>
    ALLOCATE_HOST_MEMORY = 1 << 0,

    /// <summary>
    /// Allocate device memory
    /// </summary>
    ALLOCATE_DEVICE_MEMORY = 1 << 1,

    /// <summary>
    /// Allocate shared memory. It is not equal to: USAGE_ALLOCATE_HOST_MEMORY | USAGE_ALLOCATE_DEVICE_MEMORY
    /// </summary>
    ALLOCATE_SHARED_MEMORY = 1 << 2,

    /// <summary>
    /// Binary compatibility hint
    /// </summary>
    // ReSharper disable once InconsistentNaming
    __UMAT_USAGE_FLAGS_32BIT = 0x7fffffff
}
