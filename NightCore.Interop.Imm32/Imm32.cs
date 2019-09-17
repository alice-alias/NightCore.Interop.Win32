using System.Runtime.InteropServices;

namespace NightCore.Interop.Win32
{
    public static class Imm32
    {
        [DllImport("imm32")]
        public static extern bool ImmAssociateContextEx(HWND hWnd, HIMC hIMC, IACE dwFlags);

        [DllImport("imm32")]
        public static extern HIMC ImmGetContext(HWND hWnd);

        [DllImport("imm32")]
        public static extern HIMC ImmCreateContext();

        [DllImport("imm32")]
        public static extern bool ImmDestroyContext(HIMC hIMC);

        [DllImport("imm32")]
        public static extern bool ImmReleaseContext(HWND hWnd, HIMC hIMC);

        [DllImport("imm32")]
        public static extern int ImmGetCompositionStringW(HIMC hIMC, GCS dwIndex, byte[] buf, uint dwBufLen);

        [DllImport("imm32")]
        public static extern int ImmGetCandidateListW(HIMC hIMC, uint dwIndex, byte[] buf, uint dwBufLen);

        [DllImport("imm32")]
        public static extern bool ImmGetOpenStatus(HIMC hIMC);

        [DllImport("imm32")]
        public static extern bool ImmSetOpenStatus(HIMC hIMC, int @bool);

        [DllImport("imm32")]
        public static extern uint ImmGetDescriptionW(HKL hKL, byte[] lpszDescription, uint uBufLen);

        [DllImport("imm32")]
        public static extern int ImmGetConversionStatus(HIMC hIMC, out IME_CMODE lpfdwConversion, out IME_SMODE lpfdwSentence);
    }
}
