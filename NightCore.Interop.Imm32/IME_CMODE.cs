namespace NightCore.Interop.Win32
{
    public enum IME_CMODE : uint
    {
        ALPHANUMERIC = 0x0000,
        NATIVE = 0x0001,
        CHINESE = NATIVE,
        HANGUL = NATIVE,
        JAPANESE = NATIVE,
        KATAKANA = 0x0002,
        LANGUAGE = 0x0003,
        FULLSHAPE = 0x0008,
        ROMAN = 0x0010,
        CHARCODE = 0x0020,
        HANJACONVERT = 0x0040,
        NATIVESYMBOL = 0x0080,
        HANGEUL = NATIVE,
        SOFTKBD = 0x0080,
        NOCONVERSION = 0x0100,
        EUDC = 0x0200,
        SYMBOL = 0x0400,
        FIXED = 0x0800,
    }
}
