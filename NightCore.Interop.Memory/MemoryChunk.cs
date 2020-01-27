using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace NightCore.Interop
{
    public sealed class MemoryChunk : SafeHandle
    {
        public int Size { get; }

        private MemoryChunk(IntPtr handle, int size) : base(IntPtr.Zero, true)
        {
            this.handle = handle;
            Size = size;
            GC.AddMemoryPressure(size);
        }

        public override bool IsInvalid => handle.ToInt64() <= 0;

        protected override bool ReleaseHandle()
        {
            if (IsInvalid)
                return false;

            Marshal.FreeCoTaskMem(handle);
            handle = IntPtr.Zero;

            GC.RemoveMemoryPressure(Size);
            return true;
        }

        public IntPtr Pointer => handle;

        public static MemoryChunk Alloc(int size)
        {
            return new MemoryChunk(Marshal.AllocCoTaskMem(size), size);
        }

        public unsafe static MemoryChunk Copy<T>(T[] data) where T : struct
        {
            using var array = StructHandle.Pin(data);

            var mem = Alloc(array.Size);
            using (var reader = new UnmanagedMemoryStream((byte*)array.Pointer.ToPointer(), array.Size))
            using (var writer = new UnmanagedMemoryStream((byte*)mem.Pointer.ToPointer(), mem.Size))
            {
                reader.CopyTo(writer);
            }
            return mem;
        }

        public static MemoryChunk Copy<T>(T data) where T : struct => Copy(new[] { data });

        public static MemoryChunk Copy(string data, Encoding encoding) => Copy(encoding.GetBytes(data));
    }
}
