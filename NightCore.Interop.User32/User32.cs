using System.Runtime.InteropServices;

namespace NightCore.Interop.Win32
{
    public static class User32
    {
        [DllImport("user32")]
        public static extern bool PeekMessage(out Message msg, HWND hWnd, uint messageFilterMin, uint messageFilterMax, PM flags);

        [DllImport("user32")]
        public static extern HKL GetKeyboardLayout(ThreadId idThread);
    }
}
