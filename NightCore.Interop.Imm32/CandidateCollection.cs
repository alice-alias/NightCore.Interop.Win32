using System.Collections.Generic;

namespace NightCore.Interop.Win32
{
    public class CandidateCollection : IReadOnlyList<string>
    {
        readonly string[] candidates;
        public int SelectedIndex { get; }
        public int PageStart { get; }
        public int PageSize { get; }

        unsafe public CandidateCollection(byte[] buf)
        {
            fixed (byte* p = buf)
            {
                var cl = (CANDIDATELIST*)p;

                candidates = new string[cl->dwCount];
                for (var i = 0; i < candidates.Length; i++)
                {
                    candidates[i] = new string((char*)(p + cl->dwOffset[i]));
                }

                SelectedIndex = (int)cl->dwSelection;
                PageStart = (int)cl->dwPageStart;
                PageSize = (int)cl->dwPageSize;
            }
        }

        public string this[int index] => candidates[index];

        public int Count => candidates.Length;

        public IEnumerator<string> GetEnumerator()
        {
            foreach (var i in candidates)
                yield return i;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
