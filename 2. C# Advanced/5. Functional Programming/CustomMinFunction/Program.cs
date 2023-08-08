using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> smallest = x => x.Min();
            int min = smallest(nums);
            Console.WriteLine(min);
        }
    }
}
