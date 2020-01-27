using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace NightCore.Interop
{
    public sealed class StructHandle : IDisposable
    {
        readonly GCHandle handle;

        public int Size { get; }

        private StructHandle(GCHandle handle, int size)
        {
            this.handle = handle;
            Size = size;
        }

        public static StructHandle Pin<T>(T[] array) where T : struct
            => new StructHandle(GCHandle.Alloc(array, GCHandleType.Pinned), Marshal.SizeOf<T>() * array.Length);

        public static StructHandle Pin<T>(T target) where T : struct
            => new StructHandle(GCHandle.Alloc(target, GCHandleType.Pinned), Marshal.SizeOf<T>());

        public IntPtr Pointer => handle.AddrOfPinnedObject();

        int disposed;

        public void Dispose()
        {
            if (Interlocked.Exchange(ref disposed, 1) == 0)
            {
                handle.Free();
            }
        }

        ~StructHandle() => Dispose();
    }
}
