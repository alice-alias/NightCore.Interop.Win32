namespace NightCore.Interop.Win32
{
    public enum WM_IME : int
    {
        STARTCOMPOSITION = 0x010D,
        ENDCOMPOSITION = 0x010E,
        COMPOSITION = 0x010F,
        KEYLAST = 0x010F,

        SETCONTEXT = 0x0281,
        NOTIFY = 0x0282,
        CONTROL = 0x0283,
        COMPOSITIONFULL = 0x0284,
        SELECT = 0x0285,
        CHAR = 0x0286,
        REQUEST = 0x0288,
        KEYDOWN = 0x0290,
        KEYUP = 0x0291,
    }
}
