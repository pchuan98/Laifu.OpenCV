namespace Laifu.OpenCv.PInvoke;

partial class NativeMethods
{
    [LibraryImport(LibraryName, EntryPoint = "api_array_input_create_by_mat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Array_InputCreate(MatHandle input, out InputArrayHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_array_input_create_by_matexpr")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Array_InputCreate(MatExprHandle input, out InputArrayHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_array_input_delete")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Array_InputDelete(IntPtr input);

    [LibraryImport(LibraryName, EntryPoint = "api_array_input_get_mat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Array_InputToMat(InputArrayHandle input, int idx, out MatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_array_output_create_by_mat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Array_OutputCreate(MatHandle input, out OutputArrayHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_array_output_delete")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Array_OutputDelete(IntPtr output);

    [LibraryImport(LibraryName, EntryPoint = "api_array_inputoutput_create_by_mat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Array_InputOutputCreate(MatHandle input, out InputOutputArrayHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_array_inputoutput_delete")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Array_InputOutputDelete(IntPtr output);
}