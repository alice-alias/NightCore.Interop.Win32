using System;
using System.Runtime.InteropServices;

namespace NightCore.Interop.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Message
    {
        public IntPtr HWnd;
        public uint message;
        public IntPtr WParam;
        public IntPtr LParam;
        public int time;
        public Point Point;
        public int LPrivate;
    }
}
