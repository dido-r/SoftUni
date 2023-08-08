using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> list;

        public Lake(List<int> list)
        {
            this.list = new List<int>(list);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return list[i];
                }
            }
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return list[i];
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
