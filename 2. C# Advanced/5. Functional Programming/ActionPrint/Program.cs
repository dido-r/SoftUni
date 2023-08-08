using System;
using System.Linq;

namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string> print = x => Console.WriteLine(x);
            
            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
