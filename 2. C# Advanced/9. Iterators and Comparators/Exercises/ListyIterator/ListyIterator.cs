using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace IteratorsAndComparators
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int index = 0;

        public ListyIterator()
        {
            list = new List<T>();
        }
        public ListyIterator(T[] elements)
        {
            list = new List<T>(elements);
        }
        public bool Move()
        {
            if (++index < list.Count)
            {
                return true;
            }
            else
            {
                --index;
                return false;
            }
        }
        public void Print()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(list[index]); ;
            }
        }
        public bool HasNext()
        {
            if (++index < list.Count)
            {
                --index;
                return true;
            }
            else
            {
                --index;
                return false;
            }
        }

        public void PrintAll()
        {
            if (list.Count() == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(string.Join(" ", list));
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
