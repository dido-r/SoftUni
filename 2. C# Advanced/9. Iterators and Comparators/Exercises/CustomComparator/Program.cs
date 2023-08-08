using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomComparator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arr1 = array.Where(x => x % 2 == 0).OrderBy(x => x).ToArray();
            int[] arr2 = array.Where(x => x % 2 != 0).OrderBy(x => x).ToArray();
            Console.WriteLine(string.Join(" ", arr1) + " " + string.Join(" ", arr2));
        }
    }
}
