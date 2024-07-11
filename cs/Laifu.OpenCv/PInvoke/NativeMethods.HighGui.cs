using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Laifu.OpenCv.PInvoke.Handles;

namespace Laifu.OpenCv.PInvoke;

partial class NativeMethods
{
    [LibraryImport(LibraryName, EntryPoint = "api_gui_namedWindow",
        StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_NamedWindow(string winname, int flags);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_destroyAllWindows")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_DestroyAllWindows();

    [LibraryImport(LibraryName, EntryPoint = "api_gui_destroyWindow",
        StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_DestroyWindow(string winname);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_startWindowThread")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_StartWindowThread(out int ret);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_waitKeyEx")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_WaitKeyEx(int delay, out int ret);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_waitKey")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_WaitKey(int delay, out int ret);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_imshow",
        StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_ImShow(string winname, MatHandle mat);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_imshow_umat",
        StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_ImShowUmat(string winname, UMatHandle mat);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_resizeWindow",
        StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_ResizeWindow(string winname, int width, int height);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_moveWindow",
        StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_MoveWindow(string winname, int x, int y);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_setWindowProperty",
        StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_SetWindowProperty(string winname, int prop_id, double prop_value);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_setWindowTitle",
        StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_SetWindowTitle(string winname, string title);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_getWindowProperty",
        StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_GetWindowProperty(string winname, int prop_id, out double ret);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_setMouseCallback",
        StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_SetMouseCallback(string winname, MouseCallback onMouse, IntPtr userdata);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_getMouseWheelDelta")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_GetMouseWheelDelta(int flags, out int ret);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_createTrackbar",
        StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_CreateTrackbar(string trackbarName, string winName, ref int value, int count, TrackbarCallback onChange, IntPtr userData, out int ret);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_getTrackbarPos",
        StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_GetTrackbarPos(string trackbarname, string winname, out int ret);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_setTrackbarPos",
        StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_SetTrackbarPos(string trackbarname, string winname, int pos);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_setTrackbarMax",
        StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_SetTrackbarMax(string trackbarname, string winname, int maxval);

    [LibraryImport(LibraryName, EntryPoint = "api_gui_setTrackbarMin",
        StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Gui_SetTrackbarMin(string trackbarname, string winname, int minval);
}
