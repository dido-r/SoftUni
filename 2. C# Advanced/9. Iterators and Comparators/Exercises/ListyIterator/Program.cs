using System;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] create = Console.ReadLine().Split();
            var list = new ListyIterator<string>();

            if (create.Length > 0)
            {
                string[] arr = new string[create.Length - 1];

                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = create[i + 1];
                }
                list = new ListyIterator<string>(arr);
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input == "Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if (input == "Print")
                {
                    list.Print();
                }
                else if (input == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }
                else if (input == "PrintAll")
                {
                    list.PrintAll();
                }
                input = Console.ReadLine();
            }
        }
    }
}
