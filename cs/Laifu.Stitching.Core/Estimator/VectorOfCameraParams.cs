using Laifu.OpenCv.Native.Constants;
using Laifu.OpenCv.Native;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Laifu.OpenCv;

namespace Laifu.Stitching.Core.Estimator;

internal static partial class VectorOfCameraParamsHelper
{
    private const string Name = "OpenCvSharpExtern";

    [LibraryImport(Name, EntryPoint = "api_modules_camera_params_vec_size")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int Size(StdVectorHandle vector);

    [LibraryImport(Name, EntryPoint = "api_modules_camera_params_vec_at")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus At(StdVectorHandle vector, int index, out SafePtrHandle cameraParams);
}

public class VectorOfCameraParams(StdVectorHandle handle) : DisposableObject
{
    public StdVectorHandle Handle => handle;

    public int Size => VectorOfCameraParamsHelper.Size(handle);

    public CameraParams At(int index)
    {
        VectorOfCameraParamsHelper.At(handle, index, out var ptr)
            .ThrowHandleException();
        return new CameraParams(ptr);
    }

    public CameraParams[] ToArray()
    {
        var size = Size;
        var array = new CameraParams[size];

        for (var i = 0; i < size; i++)
        {
            array[i] = At(i);
        }

        return array;
    }
}