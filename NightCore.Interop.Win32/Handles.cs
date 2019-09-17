using System;

namespace NightCore.Interop.Win32
{
    public struct HWND : IHandle
    {
        public HWND(IntPtr handle) => Handle = handle;

        public IntPtr Handle;

        IntPtr IHandle.Handle => Handle;

        public static implicit operator IntPtr(HWND h) => h.Handle;
        public static explicit operator HWND(IntPtr h) => new HWND(h);

        public static HWND Null => new HWND();
    }

    public struct HKL : IHandle
    {
        public HKL(IntPtr handle) => Handle = handle;

        public IntPtr Handle;

        IntPtr IHandle.Handle => Handle;

        public static implicit operator IntPtr(HKL h) => h.Handle;
        public static explicit operator HKL(IntPtr h) => new HKL(h);

        public static HKL Null => new HKL();
    }
}
