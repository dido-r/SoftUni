using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (Count == 0)
            {
                return true;
            }
            return false;
        }

        public Stack<string> AddRange(IEnumerable<string> list)
        {
            foreach (var item in list)
            {
                Push(item);
            }
            return this;
        }
    }
}
