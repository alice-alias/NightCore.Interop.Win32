using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace NightCore.Interop.Com
{
    public class Vtable : IReadOnlyCollection<IntPtr>
    {
        readonly List<(Delegate, IntPtr)> delegates = new List<(Delegate, IntPtr)>();

        public IEnumerable<IntPtr> Pointers => delegates.Select(x => x.Item2);

        public void Add(Delegate @delegate)
            => delegates.Add((@delegate, Marshal.GetFunctionPointerForDelegate(@delegate)));

        public Delegate this[int i]
        {
            get => delegates[i].Item1;
            set => delegates[i] = (value, Marshal.GetFunctionPointerForDelegate(value));
        }

        public int Count => delegates.Count;
        public IEnumerator<IntPtr> GetEnumerator() => Pointers.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
