using System;
using System.Collections.Generic;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> prices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            Func<double, double> vatAdding = x => x * 1.20;
            
           
            foreach (var price in prices.Select(x => vatAdding(x)))
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
