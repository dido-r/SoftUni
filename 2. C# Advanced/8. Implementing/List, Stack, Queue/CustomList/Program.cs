using System;

namespace Implementing
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.Swap(0, 4);

            list.RemoveAt(1);
            list.RemoveAt(2);
            list.RemoveAt(10);

            Console.WriteLine(list.Contains(2));
        }
    }
}
