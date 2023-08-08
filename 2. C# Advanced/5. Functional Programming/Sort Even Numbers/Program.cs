using System;
using System.Linq;

namespace SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(", ", (Console.ReadLine().Split(", ").Select(int.Parse).ToArray()).Where(x => x % 2 == 0).OrderBy(x => x)));
        }
    }
}
