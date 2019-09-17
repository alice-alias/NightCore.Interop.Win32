namespace NightCore.Interop.Win32
{
    public static class Extensions
    {
        public static bool ImmAssociateContextEx(this HWND hWnd, HIMC hIMC, IACE dwFlags)
            => Imm32.ImmAssociateContextEx(hWnd, hIMC, dwFlags);

        public static HIMC ImmGetContext(this HWND hWnd)
            => Imm32.ImmGetContext(hWnd);

        public static bool ImmReleaseContext(this HWND hWnd, HIMC hIMC)
            => Imm32.ImmReleaseContext(hWnd, hIMC);

        public static string ImmGetCompositionString(this HIMC hIMC, GCS dwIndex)
            => BufferReader.ReadString((buf, size) => Imm32.ImmGetCompositionStringW(hIMC, dwIndex, buf, size));

        public static CandidateCollection ImmGetCandidateList(this HIMC hIMC)
            => new CandidateCollection(BufferReader.ReadBytes((buf, size) => Imm32.ImmGetCandidateListW(hIMC, 0, buf, size)));

        public static bool ImmGetOpenStatus(this HIMC hIMC) => Imm32.ImmGetOpenStatus(hIMC);

        public static void ImmSetOpenStatus(this HIMC hIMC, bool status) => Imm32.ImmSetOpenStatus(hIMC, status ? -1 : 0);

        public static string ImmGetDescription(this HKL hKL)
            => BufferReader.ReadString((buf, size) => Imm32.ImmGetDescriptionW(hKL, buf, size));

        public static (IME_CMODE, IME_SMODE) ImmGetConversionStatus(this HIMC hIMC)
        {
            Imm32.ImmGetConversionStatus(hIMC, out var cmode, out var smode);
            return (cmode, smode);
        }

        public static bool ImmDestroyContext(this HIMC hIMC)
            => Imm32.ImmDestroyContext(hIMC);
    }
}
