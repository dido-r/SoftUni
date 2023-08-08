using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class CustomStack
    {
        private const int initialCapacity = 4;
        private int[] stack = new int[initialCapacity];
        private int mainIndex = 0;
        public int Count { get { return mainIndex; } private set { } }

        public void Push(int element)
        {
            Resize();
            stack[mainIndex++] = element;
            Shrink();
        }
        public int Pop()
        {
            int num = stack[mainIndex - 1];
            mainIndex--;
            Shrink();
            return num;
        }
        public int Peek()
        {
            return stack[mainIndex - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(stack[i]);
            }
        }

        public void Resize()
        {
            if (mainIndex == stack.Length)
            {
                int[] newList = new int[stack.Length * 2];

                for (int i = 0; i < stack.Length; i++)
                {
                    newList[i] = stack[i];
                }
                stack = newList;
            }
        }

        public void Shrink()
        {
            if (stack.Length > mainIndex)
            {
                int[] newList = new int[Count];

                for (int i = 0; i < Count; i++)
                {
                    newList[i] = stack[i];
                }
                stack = newList;
            }
        }
    }
}
