using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Laifu.Stitching.Core.Models;

[StructLayout(LayoutKind.Sequential)]
public struct CvSize(int width, int height)
{
    public int width = width;
    public int height = height;

    public static implicit operator Size(CvSize size)
        => new(size.width, size.height);

    public override string ToString() => $"CvSize(width: {width}, height: {height})";
}

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct DMatch(int QueryIndex, int TrainIndex, int ImageIndex, float Distance);