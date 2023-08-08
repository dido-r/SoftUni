using System;
using System.Linq;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            var result = DateModifier.DaysCalcule(first, second);
            Console.WriteLine(result);
        }
    }
}
