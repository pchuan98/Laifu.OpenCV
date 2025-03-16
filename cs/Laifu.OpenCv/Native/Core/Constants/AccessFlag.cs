﻿namespace Laifu.OpenCv.Native.Core.Constants;


[Flags]
public enum AccessFlag
{
    ACCESS_READ = 1 << 24, 
    ACCESS_WRITE = 1 << 25,
    ACCESS_RW = 3 << 24, 
    ACCESS_MASK = ACCESS_RW, 
    ACCESS_FAST = 1 << 26
}