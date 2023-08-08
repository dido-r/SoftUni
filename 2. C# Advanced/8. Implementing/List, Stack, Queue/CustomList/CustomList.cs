using System;
using System.Collections.Generic;
using System.Text;

namespace Implementing
{
    public class CustomList
    {
        public int[] list = new int[2];
        private int mainIndex = 0;

        public int Count { get { return mainIndex; } set { } }

        public void Add(int element)
        {
            Resize();
            list[mainIndex++] = element;
            Shrink();
        }

        public int RemoveAt(int index)
        {
            InRange(index);
            int number = list[index];

            for (int i = index; i < Count - 1; i++)
            {
                list[i] = list[i + 1];
            }
            mainIndex--;
            Shrink();
            return number;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (list[i] == element)
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            InRange(firstIndex);
            InRange(secondIndex);
            int current = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = current;
        }
        public void Resize()
        {
            if (mainIndex == list.Length)
            {
                int[] newList = new int[list.Length * 2];

                for (int i = 0; i < list.Length; i++)
                {
                    newList[i] = list[i];
                }

                list = newList;
            }
        }

        public void Shrink()
        {
            if (list.Length > mainIndex)
            {
                int[] newList = new int[Count];

                for (int i = 0; i < Count; i++)
                {
                    newList[i] = list[i];
                }
                list = newList;
            }
        }

        public void InRange(int checkIndex)
        {
            if (checkIndex < 0 || checkIndex >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
