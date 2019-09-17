using System;

namespace NightCore.Interop.Win32
{
    public static class Extensions
    {
        public static bool IsNull(this IHandle handle) => handle.Handle == IntPtr.Zero;
    }
}
