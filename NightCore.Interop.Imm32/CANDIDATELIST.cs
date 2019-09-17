namespace NightCore.Interop.Win32
{
    unsafe struct CANDIDATELIST
    {
#pragma warning disable 0649
        public uint dwSize;
        public uint dwStyle;
        public uint dwCount;
        public uint dwSelection;
        public uint dwPageStart;
        public uint dwPageSize;
#pragma warning restore 0649
        public fixed uint dwOffset[1];
    }
}
