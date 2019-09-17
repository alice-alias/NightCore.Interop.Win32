namespace NightCore.Interop.Win32
{
    public static class Extensions
    {
        public static HKL GetKeyboardLayout(this ThreadId thread) => User32.GetKeyboardLayout(thread);

        public static bool PeekMessage(this HWND hWnd, out Message msg, uint messageFilterMin, uint messageFilterMax, PM flags)
            => User32.PeekMessage(out msg, hWnd, messageFilterMin, messageFilterMax, flags);
    }
}
