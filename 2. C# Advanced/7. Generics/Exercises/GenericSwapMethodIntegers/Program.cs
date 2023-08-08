using System;
using System.Linq;
using System.Collections.Generic;

namespace GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap(list, input[0], input[1]);
            list.ForEach(x => Console.WriteLine($"{x.GetType()}: {x}"));
        }

        public static void Add<T>(List<T> list, T element)
        {
            list.Add(element);
        }

        public static List<T> Swap<T>(List<T> list, int first, int second)
        {
            var current = list[first];
            list[first] = list[second];
            list[second] = current;
            return list;
        }
    }
}
