using System;
using System.Collections.Generic;
using System.Text;

namespace CustomQueue
{
    public class CustomQueue
    {
        private const int capacity = 4;
        private int[] queue = new int[capacity];
        private int mainIndex = 0;


        public void Enqueue(int element)
        {
            Resize();
            queue[mainIndex++] = element;
            Shrink();
        }

        public int Dequeue()
        {
            int num = queue[0];
            mainIndex--;
            int[] newList = new int[queue.Length - 1];

            for (int i = 0; i < newList.Length; i++)
            {
                newList[i] = queue[i + 1];
            }
            queue = newList;
            return num;
        }

        public int Peek()
        {
            return queue[0];
        }

        public void Cleer()
        {
            queue = new int[capacity];
        }
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < mainIndex; i++)
            {
                action(queue[i]);
            }
        }

        public void Resize()
        {
            if (mainIndex == queue.Length)
            {
                int[] newList = new int[queue.Length * 2];

                for (int i = 0; i < queue.Length; i++)
                {
                    newList[i] = queue[i];
                }
                queue = newList;
            }
        }

        public void Shrink()
        {
            if (queue.Length > mainIndex)
            {
                int[] newList = new int[mainIndex];

                for (int i = 0; i < mainIndex; i++)
                {
                    newList[i] = queue[i];
                }
                queue = newList;
            }
        }
    }
}
