using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> isUpper = x => char.IsUpper(x[0]);
            Console.WriteLine(string.Join("\n", text.Where(isUpper)));
        }
    }
}
