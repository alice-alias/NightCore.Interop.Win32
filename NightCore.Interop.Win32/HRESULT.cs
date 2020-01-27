using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NightCore.Interop.Win32
{
    public struct HRESULT
    {
        readonly int value;
        private HRESULT(int value) => this.value = value;

        public override string ToString() => $"0x{value:X08}";

        public bool IsSucceed => value >= 0;
        public bool IsFalied => value < 0;

        public void ThrowIfFailed()
        {
            if (value < 0)
                Marshal.ThrowExceptionForHR(value);
        }

        public static explicit operator int(HRESULT v) => v.value;
        public static explicit operator HRESULT(int v) => new HRESULT(v);
        public static explicit operator HRESULT(uint v) => new HRESULT((int)v);

        public override bool Equals(object obj) => obj is HRESULT o && o.value == value;
        public override int GetHashCode() => value;
        public static bool operator ==(HRESULT left, HRESULT right) => left.Equals(right);
        public static bool operator !=(HRESULT left, HRESULT right) => !(left == right);

#pragma warning disable IDE1006
        public static HRESULT S_OK => (HRESULT)0;
#pragma warning restore IDE1006
        public static HRESULT E_FAIL => (HRESULT)0x80004005;
        public static HRESULT E_NOINTERFACE => (HRESULT)0x80004002;
        public static HRESULT E_INVALIDARG => (HRESULT)0x80070057;
    }
}
