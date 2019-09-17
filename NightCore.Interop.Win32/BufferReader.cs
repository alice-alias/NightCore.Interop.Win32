using System;
using System.ComponentModel;
using System.Text;

namespace NightCore.Interop.Win32
{
    public static class BufferReader
    {
        public static byte[] ReadBytes(Func<byte[], uint, int> func)
        {
            var len = func(null, 0);
            if (len < 0)
                throw new Win32Exception(len);

            var buf = new byte[len];
            var result = func(buf, (uint)len);
            if (result < 0)
                throw new Win32Exception(result);

            return buf;
        }

        public static byte[] ReadBytes(Func<byte[], uint, uint> func)
        {
            var buf = new byte[func(null, 0)];
            func(buf, (uint)buf.Length);
            return buf;
        }

        public static string ReadString(Func<byte[], uint, int> func)
            => Encoding.Unicode.GetString(ReadBytes(func));

        public static string ReadString(Func<byte[], uint, uint> func)
            => Encoding.Unicode.GetString(ReadBytes(func));
    }
}
