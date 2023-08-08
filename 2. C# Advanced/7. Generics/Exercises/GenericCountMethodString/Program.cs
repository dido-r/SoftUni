using System;
using System.Linq;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }
            string element = Console.ReadLine();
            Console.WriteLine(IsGreater(list, element));
        }

        public static int IsGreater<T>(List<T> list, T element)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (((IComparable)item).CompareTo((IComparable)element) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
