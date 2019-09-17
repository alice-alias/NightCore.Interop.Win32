using System;

namespace NightCore.Interop.Win32
{
    [Flags]
    public enum IACE : uint
    {
        CHILDREN = 0x0001,
        DEFAULT = 0x0010,
        IGNORENOCONTEXT = 0x0020
    }
}
