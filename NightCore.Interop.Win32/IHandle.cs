using System;

namespace NightCore.Interop.Win32
{
    public interface IHandle
    {
        IntPtr Handle { get; }
    }
}
