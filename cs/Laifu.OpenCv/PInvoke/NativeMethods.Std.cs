using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laifu.OpenCv.PInvoke;

partial class NativeMethods
{
    [LibraryImport(LibraryName, EntryPoint = "api_std_delete")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Std_Delete(nint ptr);

    [LibraryImport(LibraryName, EntryPoint = "api_std_vector_create_keypoint1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial StdVectorHandle Std_Vector_Create_KeyPoint();

    [LibraryImport(LibraryName, EntryPoint = "api_std_vector_create_keypoint2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial StdVectorHandle Std_Vector_Create_KeyPoint(uint size);

    [LibraryImport(LibraryName, EntryPoint = "api_std_vector_create_keypoint3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial StdVectorHandle Std_Vector_Create_KeyPoint([In] KeyPoints[] points, nuint length);

    [LibraryImport(LibraryName, EntryPoint = "api_std_vector_size_keypoint")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int Std_Vector_Size_KeyPoint(StdVectorHandle vector);

    [LibraryImport(LibraryName, EntryPoint = "api_std_vector_data_keypoint")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial SafePtrHandle Std_Vector_Data_KeyPoint(StdVectorHandle vector);
}