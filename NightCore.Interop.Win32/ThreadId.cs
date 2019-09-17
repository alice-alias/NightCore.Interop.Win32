namespace NightCore.Interop.Win32
{
    public struct ThreadId
    {
        public uint Id;

        public ThreadId(uint id) => Id = id;
    }
}
