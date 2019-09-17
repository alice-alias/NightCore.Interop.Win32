namespace NightCore.Interop.Win32
{
    public enum IME_SMODE : uint
    {
        NONE = 0x0000,
        PLAURALCLAUSE = 0x0001,
        SINGLECONVERT = 0x0002,
        AUTOMATIC = 0x0004,
        PHRASEPREDICT = 0x0008,
        CONVERSATION = 0x0010,
    }
}
