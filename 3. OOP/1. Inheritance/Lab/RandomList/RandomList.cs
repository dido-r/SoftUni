using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString(IEnumerable<string> list)
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            Random random = new Random();
            int index = random.Next(0, Count - 1);
            var item = this[index];
            RemoveAt(index);
            return item;
        }
    }
}
