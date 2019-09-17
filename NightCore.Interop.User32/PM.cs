using System;

namespace NightCore.Interop.Win32
{
    [Flags]
    public enum PM : uint
    {
        NOREMOVE = 0x0000,
        REMOVE = 0x0001,
        NOYIELD = 0x0002,

        QS_INPUT = QS.INPUT << 16,
        QS_PAINT = QS.PAINT << 16,
        QS_POSTMESSAGE = (QS.POSTMESSAGE | QS.HOTKEY | QS.TIMER) << 16,

        QS_SENDMESSAGE = QS.SENDMESSAGE << 16,
    }
}
