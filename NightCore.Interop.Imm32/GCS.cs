using System;

namespace NightCore.Interop.Win32
{
    [Flags]
    public enum GCS : uint
    {
        COMPATTR = 0x10,
        COMPCLAUSE = 0x20,
        COMPREADATTR = 0x2,
        COMPREADCLAUSE = 0x4,
        COMPREADSTR = 0x1,
        COMPSTR = 0x8,
        CURSORPOS = 0x80,
        DELTASTART = 0x100,
        RESULTCLAUSE = 0x1000,
        RESULTREADCLAUSE = 0x400,
        RESULTREADSTR = 0x200,
        RESULTSTR = 0x800,
    }
}
