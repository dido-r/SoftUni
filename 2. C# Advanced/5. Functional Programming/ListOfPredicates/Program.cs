using System;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Action<int> filter = IsDevisible(dividers, range);
            filter(range);
        }

        private static Action<int> IsDevisible(int[] dividers, int range)
        {
            for (int i = 1; i <= range; i++)
            {
                bool isDivisible = true;

                foreach (var item in dividers)
                {
                    if (i % item != 0)
                    {
                        isDivisible = false;
                    }
                }
                if (isDivisible)
                {
                    Console.Write(i + " ");
                }
            }
            return x => Console.Write("");
        }
    }
}
