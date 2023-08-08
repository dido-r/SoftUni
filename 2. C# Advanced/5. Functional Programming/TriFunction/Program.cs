using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
            Func<string, int, bool> filter = (x, y) => x.ToCharArray().Sum(c => (int)c) >= y;
            Func<List<string>, Func<string, int, bool>, int, string> result = (x, y, n) => x.First(c => y(c, n));
            Console.WriteLine(result(names, filter, n));
        }
    }
}
