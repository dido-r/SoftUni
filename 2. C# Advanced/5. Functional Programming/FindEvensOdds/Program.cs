using System;
using System.Linq;

namespace FindEvensOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int start = range[0];
            int end = range[1];
            string criteria = Console.ReadLine();
            Predicate<int> filter = OddOrEven(criteria);
            
            for (int i = start; i <= end; i++)
            {
                if (filter(i))
                {
                    Console.Write(i + " ");
                }
            }
        }

        private static Predicate<int> OddOrEven(string criteria)
        {
            if (criteria == "odd")
            {
                return x => x % 2 != 0;
            }
            else if (criteria == "even")
            {
                return x => x % 2 == 0;
            }
            return null;
        }
    }
}
