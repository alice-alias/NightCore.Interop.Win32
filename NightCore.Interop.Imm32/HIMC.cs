using System;

namespace NightCore.Interop.Win32
{
    public struct HIMC : IHandle
    {
        public HIMC(IntPtr handle) => Handle = handle;

        public IntPtr Handle;

        IntPtr IHandle.Handle => Handle;

        public static implicit operator IntPtr(HIMC h) => h.Handle;
        public static explicit operator HIMC(IntPtr h) => new HIMC(h);

        public static HIMC Null => new HIMC();
    }
}
