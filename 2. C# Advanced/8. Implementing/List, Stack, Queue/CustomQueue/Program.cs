using System;

namespace CustomQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomQueue queue = new CustomQueue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Action<int> act = new Action<int>(x => Console.WriteLine(x));
            queue.ForEach(act);
        }
    }
}
