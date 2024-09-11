using Laifu.OpenCv.Native.Constants;
using Laifu.OpenCv.Native;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Laifu.OpenCv;

namespace Laifu.Stitching.Core.Finder;

internal static partial class VectorOfImageFeaturesHelper
{
    private const string Name = "OpenCvSharpExtern";

    [LibraryImport(Name, EntryPoint = "api_modules_features_vec_size")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int Size(StdVectorHandle vector);

    [LibraryImport(Name, EntryPoint = "api_modules_features_vec_at")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus At(StdVectorHandle vector, int index, out SafePtrHandle imageFeatures);
}

public class VectorOfImageFeatures(StdVectorHandle handle) : DisposableObject
{
    public StdVectorHandle Handle => handle;

    public int Size => VectorOfImageFeaturesHelper.Size(handle);

    public ImageFeatures At(int index)
    {
        VectorOfImageFeaturesHelper.At(handle, index, out var ptr)
            .ThrowHandleException();
        return new ImageFeatures(ptr);
    }

    public ImageFeatures[] ToArray()
    {
        var size = Size;
        var array = new ImageFeatures[size];

        for (var i = 0; i < size; i++)
        {
            array[i] = At(i);
        }

        return array;
    }
}
