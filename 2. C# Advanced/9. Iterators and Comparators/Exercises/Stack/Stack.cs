using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] stack;

        public Stack(T[] elements)
        {
            stack = new T[elements.Length];

            for (int i = 0; i < elements.Length; i++)
            {
                stack[i] = elements[i];
            }
        }

        public void Push(T element)
        {
            var arr = new T[stack.Length + 1];

            for (int i = 0; i < stack.Length; i++)
            {
                arr[i] = stack[i];
            }
            arr[arr.Length - 1] = element;
            stack = arr;
        }
        public void Pop()
        {
            if (stack.Length == 0)
            {
                Console.WriteLine("No elements");
            }
            else
            {
                var arr = new T[stack.Length - 1];

                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = stack[i];
                }
                stack = arr;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = stack.Length - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
            for (int i = stack.Length - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
