using System;

namespace NightCore.Interop.Win32
{
    [Flags]
    public enum QS : uint
    {
        // TODO: all constatns

        KEY = 0x0001,
        MOUSEMOVE = 0x0002,
        MOUSEBUTTON = 0x0004,
        POSTMESSAGE = 0x0008,
        TIMER = 0x0010,
        PAINT = 0x0020,
        SENDMESSAGE = 0x0040,
        HOTKEY = 0x0080,

        RAWINPUT = 0x0400,

        INPUT = MOUSE | KEY | RAWINPUT,
        MOUSE = MOUSEMOVE | MOUSEBUTTON,
    }
}
