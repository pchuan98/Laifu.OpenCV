using Laifu.OpenCv.Models.Vectors;

namespace Laifu.OpenCv;

public static partial class Test
{
    [LibraryImport("OpenCvSharpExtern", EntryPoint = "api_create_feature"),
     UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void API_GET(out SafePtrHandle output);

    [LibraryImport("OpenCvSharpExtern", EntryPoint = "api_test_feature"),
        UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void API_TEST(SafePtrHandle handle);

    [LibraryImport("OpenCvSharpExtern", EntryPoint = "api_feature_keypoints"),
     UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial StdVectorHandle API_POINTS(SafePtrHandle handle);

    [LibraryImport("OpenCvSharpExtern", EntryPoint = "api_feature_keypoints_print"),
     UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial StdVectorHandle API_PRINT(StdVectorHandle handle);

    public static void Run()
    {
        API_GET(out var handle);
        API_TEST(handle);

        var pptr = API_POINTS(handle);   
        var points = new VectorOfKeyPoint(pptr);

        Console.WriteLine(points.Size);
        var keys = points.ToArray();

        Console.WriteLine(keys[0]);
        Console.WriteLine(keys[points.Size - 1]);

        var back = new VectorOfKeyPoint(keys);
        API_PRINT(back.Handle);
    }
}