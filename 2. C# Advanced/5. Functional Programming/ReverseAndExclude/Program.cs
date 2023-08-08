using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());
            Predicate<int> divisible = x => x % n != 0;
            list = list.Where(x => divisible(x)).ToList();
            Action<List<int>> reverse = Reverse(list);
            reverse(list);
        }

        private static Action<List<int>> Reverse(List<int> list)
        {
            int stop = list.Count;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (stop == i)
                {
                    break;
                }
                list.Add(list[i]);
            }
            list.RemoveRange(0, stop);
            return list => Console.WriteLine(string.Join(" ", list)); ;
        }
    }
}
