using NightCore.Interop.Win32;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NightCore.Interop.Com
{
    public abstract class ComObject
    {
        static readonly ConcurrentDictionary<IntPtr, ComObject> objects = new ConcurrentDictionary<IntPtr, ComObject>();

        object? target;
        int refCount;
        readonly StructHandle vtableHandle, objectHandle;

        protected ComObject(object target)
        {
            this.target = target;
            var list = new Vtable();
            Build(list);
            list.Add((QueryInterfaceDelegate)QueryInterface);
            list.Add((AddRefDelegate)AddRef);
            list.Add((AddRefDelegate)Release);

            vtableHandle = StructHandle.Pin(list.Pointers.ToArray());
            objectHandle = StructHandle.Pin(new[] { vtableHandle.Pointer });
            objects[Pointer] = this;
        }

        public IntPtr Pointer => objectHandle.Pointer;

        delegate HRESULT QueryInterfaceDelegate(IntPtr @this, ref Guid guid, out IntPtr data);
        delegate int AddRefDelegate(IntPtr @this);

        protected abstract void Build(Vtable vtable);

        protected static object Get(IntPtr @this) => objects[@this].target ?? throw new ObjectDisposedException(null);

        protected virtual HRESULT QueryInterface(ref Guid guid, out IntPtr data)
        {
            data = IntPtr.Zero;
            return HRESULT.E_NOINTERFACE;
        }

        protected virtual int AddRef()
        {
            return Interlocked.Increment(ref refCount);
        }

        protected virtual int Release()
        {
            var result = Interlocked.Decrement(ref refCount);
            if (result == 0)
            {
                objects.Remove(Pointer, out _);
                target = default;
                objectHandle.Dispose();
                vtableHandle.Dispose();
            }
            return result;
        }

        static HRESULT QueryInterface(IntPtr @this, ref Guid guid, out IntPtr data)
            => objects[@this].QueryInterface(ref guid, out data);

        static int AddRef(IntPtr @this)
            => objects[@this].AddRef();

        static int Release(IntPtr @this)
            => objects[@this].Release();
    }

    public abstract class ComObject<TInterface> : ComObject where TInterface : notnull
    {
        protected ComObject(TInterface target) : base(target) { }
        protected static new TInterface Get(IntPtr @this) => (TInterface)ComObject.Get(@this);
    }
}
