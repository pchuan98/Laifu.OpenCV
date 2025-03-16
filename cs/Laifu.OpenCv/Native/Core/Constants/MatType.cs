// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Constants;

// core
public readonly partial record struct MatType(int Value) : IEquatable<int>
{
    public bool Equals(MatType other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(int other)
    {
        throw new NotImplementedException();
    }

    public override int GetHashCode() => throw new NotImplementedException();

    public static implicit operator int(MatType type) => type.Value;

    public static implicit operator MatType(int value) => new(value);

    public int ToInt() => Value;

    public override string ToString()
        => $"{Depth switch
        {
            CV_8U => "CV_8U",
            CV_8S => "CV_8S",
            CV_16U => "CV_16U",
            CV_16S => "CV_16S",
            CV_32S => "CV_32S",
            CV_32F => "CV_32F",
            CV_64F => "CV_64F",
            CV_16F => "CV_16F",
            _ => "Unknown"
        }}{(Channels <= 4 ? $"C{Channels}" : $"C({Channels}")}";
}

// constant
partial record struct MatType
{
    public const int CV_CN_MAX = 512;

    public const int CV_CN_SHIFT = 3;

    public const int CV_DEPTH_MAX = (1 << CV_CN_SHIFT);

    public const int CV_8U = 0;

    public const int CV_8S = 1;

    public const int CV_16U = 2;

    public const int CV_16S = 3;

    public const int CV_32S = 4;

    public const int CV_32F = 5;

    public const int CV_64F = 6;

    public const int CV_16F = 7; // CV_USRTYPE1 support has been dropped in OpenCV 4.0

    public const int CV_MAT_DEPTH_MASK = CV_DEPTH_MAX - 1;

    public const int CV_8UC1 = 0;

    public const int CV_8UC2 = 8;

    public const int CV_8UC3 = 16;

    public const int CV_8UC4 = 24;

    public const int CV_8SC1 = 1;

    public const int CV_8SC2 = 9;

    public const int CV_8SC3 = 17;

    public const int CV_8SC4 = 25;

    public const int CV_16UC1 = 2;

    public const int CV_16UC2 = 10;

    public const int CV_16UC3 = 18;

    public const int CV_16UC4 = 26;

    public const int CV_16SC1 = 3;

    public const int CV_16SC2 = 11;

    public const int CV_16SC3 = 19;

    public const int CV_16SC4 = 27;

    public const int CV_32SC1 = 4;

    public const int CV_32SC2 = 12;

    public const int CV_32SC3 = 20;

    public const int CV_32SC4 = 28;

    public const int CV_32FC1 = 5;

    public const int CV_32FC2 = 13;

    public const int CV_32FC3 = 21;

    public const int CV_32FC4 = 29;

    public const int CV_64FC1 = 6;

    public const int CV_64FC2 = 14;

    public const int CV_64FC3 = 22;

    public const int CV_64FC4 = 30;

}

// Prop & Func
partial record struct MatType
{
    public int Depth => Value & (CV_DEPTH_MAX - 1);

    public int Channels => (Value >> CV_CN_SHIFT) + 1;

    public static MatType MakeType(int depth, int channels)
    {
        if (depth is < 0 or >= CV_DEPTH_MAX)
            throw new ArgumentException($"Data type depth should be 0..{(CV_DEPTH_MAX - 1)}", nameof(depth));
        if (channels is <= 0 or >= CV_CN_MAX)
            throw new ArgumentException($"Channels count should be 1..{(CV_CN_MAX - 1)}", nameof(channels));
        return (depth & (CV_DEPTH_MAX - 1)) + ((channels - 1) << CV_CN_SHIFT);
    }
}