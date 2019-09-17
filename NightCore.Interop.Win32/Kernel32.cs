using System.Runtime.InteropServices;

namespace NightCore.Interop.Win32
{
    public static class Kernel32
    {
        [DllImport("kernel32")]
        public static extern ThreadId GetCurrentThreadId();
    }
}
