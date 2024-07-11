using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Laifu.OpenCv.PInvoke;

partial class NativeMethods
{
    internal static partial class Mat
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [LibraryImport(LibraryName, EntryPoint = "api_mat_delete")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        internal static partial ExceptionStatus Delete(IntPtr obj);
    }
}