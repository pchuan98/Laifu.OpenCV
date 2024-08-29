namespace Laifu.OpenCv.Native.ImageCodecs;

/// <summary>
/// Methods for reading and writing images
/// </summary>
internal static partial class Method
{
    /// <summary>
    /// Reads an image from a file.
    /// </summary>
    /// <param name="filename">The name of the file to read.</param>
    /// <param name="flags">The read flags.</param>
    /// <param name="output">The output Mat handle.</param>
    /// <returns>Exception status.</returns>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_imread", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Imread(string filename, int flags, out MatHandle output);

    /// <summary>
    /// Reads multiple images from a file.
    /// </summary>
    /// <param name="filename">The name of the file to read.</param>
    /// <param name="mats">The vector handle of Mats to store the images.</param>
    /// <param name="flags">The read flags.</param>
    /// <returns>True if the images are read successfully; otherwise, false.</returns>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_imreadmulti1", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool ImreadMulti(string filename, VectorHandle mats, int flags);

    /// <summary>
    /// Reads a specified range of images from a file.
    /// </summary>
    /// <param name="filename">The name of the file to read.</param>
    /// <param name="mats">The vector handle of Mats to store the images.</param>
    /// <param name="start">The start index of images to read.</param>
    /// <param name="count">The number of images to read.</param>
    /// <param name="flags">The read flags.</param>
    /// <returns>True if the images are read successfully; otherwise, false.</returns>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_imreadmulti2", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool ImreadMulti(string filename, VectorHandle mats, int start, int count, int flags);

    /// <summary>
    /// Counts the number of images in a file.
    /// </summary>
    /// <param name="filename">The name of the file to count images in.</param>
    /// <param name="flags">The count flags.</param>
    /// <returns>The number of images.</returns>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_imcount", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int Imcount(string filename, int flags);

    /// <summary>
    /// Writes an image to a file.
    /// </summary>
    /// <param name="filename">The name of the file to write.</param>
    /// <param name="img">The Mat handle of the image.</param>
    /// <param name="params">The parameters for writing.</param>
    /// <param name="length">The length of the parameters array.</param>
    /// <returns>True if the image is written successfully; otherwise, false.</returns>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_imwrite", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool Imwrite(string filename, MatHandle img, int[] @params, int length);

    /// <summary>
    /// Writes multiple images to a file.
    /// </summary>
    /// <param name="filename">The name of the file to write.</param>
    /// <param name="mats">The vector handle of Mats containing images to write.</param>
    /// <param name="params">The parameters for writing.</param>
    /// <param name="length">The length of the parameters array.</param>
    /// <returns>True if the images are written successfully; otherwise, false.</returns>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_imwritemulti", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool ImwriteMulti(string filename, VectorHandle mats, int[] @params, int length);

    /// <summary>
    /// Decodes an image from a buffer.
    /// </summary>
    /// <param name="buf">The buffer containing the image data.</param>
    /// <param name="flags">The decode flags.</param>
    /// <param name="output">The output Mat handle.</param>
    /// <returns>Exception status.</returns>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_imdecode1", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Imdecode(MatHandle buf, int flags, out MatHandle output);

    /// <summary>
    /// Decodes an image from a buffer.
    /// </summary>
    /// <param name="buf">The buffer containing the image data.</param>
    /// <param name="flags">The decode flags.</param>
    /// <param name="output">The output Mat handle.</param>
    /// <returns>Exception status.</returns>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_imdecode2", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Imdecode(SafePtrHandle buf, int flags, out MatHandle output);

    /// <summary>
    /// Decodes an image from a buffer.
    /// </summary>
    /// <param name="buf">The buffer containing the image data.</param>
    /// <param name="length"></param>
    /// <param name="flags">The decode flags.</param>
    /// <param name="output">The output Mat handle.</param>
    /// <returns>Exception status.</returns>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_imdecode3", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static unsafe partial ExceptionStatus Imdecode(byte* buf, int length, int flags, out MatHandle output);

    /// <summary>
    /// Decodes multiple images from a buffer.
    /// </summary>
    /// <param name="buf">The buffer containing the image data.</param>
    /// <param name="flags">The decode flags.</param>
    /// <param name="mats">The vector handle of Mats to store the decoded images.</param>
    /// <returns>True if the images are decoded successfully; otherwise, false.</returns>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_imdecodemulti1", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool ImdecodeMulti(SafePtrHandle buf, int flags, VectorHandle mats);

    /// <summary>
    /// Decodes multiple images from a buffer.
    /// </summary>
    /// <param name="buf">The buffer containing the image data.</param>
    /// <param name="length"></param>
    /// <param name="flags">The decode flags.</param>
    /// <param name="mats">The vector handle of Mats to store the decoded images.</param>
    /// <returns>True if the images are decoded successfully; otherwise, false.</returns>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_imdecodemulti2", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static unsafe partial bool ImdecodeMulti(byte* buf, int length, int flags, SafePtrHandle mats);

    /// <summary>
    /// Encodes an image to a specific format.
    /// </summary>
    /// <param name="ext">The extension format to encode to.</param>
    /// <param name="img">The image to encode.</param>
    /// <param name="buf">The output buffer containing the encoded image.</param>
    /// <param name="params">The encoding parameters.</param>
    /// <param name="length">The length of the parameters array.</param>
    /// <returns>True if the image is encoded successfully; otherwise, false.</returns>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_imencode")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool Imencode([MarshalAs(UnmanagedType.LPStr)] string ext, MatHandle img, SafePtrHandle buf, int[] @params, int length);

    /// <summary>
    /// Checks if the image reader is available for the given file.
    /// </summary>
    /// <param name="filename">The name of the file to check.</param>
    /// <returns>True if the image reader is available; otherwise, false.</returns>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_haveImageReader", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool HaveImageReader(string filename);

    /// <summary>
    /// Checks if the image writer is available for the given file.
    /// </summary>
    /// <param name="filename">The name of the file to check.</param>
    /// <returns>True if the image writer is available; otherwise, false.</returns>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_haveImageWriter", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool HaveImageWriter(string filename);
}
