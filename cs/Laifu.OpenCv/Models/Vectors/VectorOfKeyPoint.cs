using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Laifu.OpenCv.PInvoke.NativeMethods;

namespace Laifu.OpenCv.Models.Vectors;

public class VectorOfKeyPoint : DisposableObject
{
    private readonly StdVectorHandle _handle;

    public StdVectorHandle Handle => _handle;

    public VectorOfKeyPoint()
    {
        _handle = Std_Vector_Create_KeyPoint();
    }

    public VectorOfKeyPoint(StdVectorHandle ptr) => _handle = ptr;

    public VectorOfKeyPoint(int size)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(size, 0);
        _handle = Std_Vector_Create_KeyPoint((uint)size);
    }

    public VectorOfKeyPoint(IEnumerable<KeyPoints> keys)
    {
        ArgumentNullException.ThrowIfNull(keys, nameof(keys));

        var array = keys.ToArray();
        _handle = Std_Vector_Create_KeyPoint(array, (nuint)array.Length);
    }

    public int Size => Std_Vector_Size_KeyPoint(_handle);

    public KeyPoints[] ToArray()
    {
        var size = Size;

        var array = new KeyPoints[size];
        var length = Marshal.SizeOf<KeyPoints>() * size;

        DataHandle = GCHandle.Alloc(array, GCHandleType.Pinned);

        unsafe
        {
            var ptr = Std_Vector_Data_KeyPoint(_handle).DangerousGetHandle();
            Buffer.MemoryCopy(ptr.ToPointer(),
                DataHandle.AddrOfPinnedObject().ToPointer(),
                length, length);
        }

        GC.KeepAlive(this);
        return array;
    }
}

