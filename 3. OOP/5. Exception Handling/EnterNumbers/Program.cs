using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = ReadNumber(1, 100);
            Console.WriteLine(string.Join(", ", list));
        }

        private static List<int> ReadNumber(int start, int end)
        {
            List<int> list = new List<int>();

            while (list.Count < 10)
            {
                try
                {
                    int n = int.Parse(Console.ReadLine());

                    if (n > start && n < end)
                    {
                        list.Add(n);
                        start = n;
                    }
                    else
                    {
                        throw new ArgumentException($"Your number is not in range {start} - 100!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
            }
            return list;
        }
    }
}
