using System;
using System.Linq;

namespace PlayCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int countExeptions = 0;

            while (countExeptions < 3)
            {
                string[] command = Console.ReadLine().Split();

                try
                {
                    if (command[0] == "Replace")
                    {
                        array[int.Parse(command[1])] = int.Parse(command[2]);
                    }
                    else if (command[0] == "Print")
                    {
                        int first = array[int.Parse(command[1])];
                        int last = array[int.Parse(command[2])];
                        int[] arr = new int[int.Parse(command[2]) - int.Parse(command[1]) + 1];

                        for (int i = 0; i < arr.Length; i++)
                        {
                            arr[i] = array[i + int.Parse(command[1])];
                        }

                        Console.WriteLine(string.Join(", ", arr));
                    }
                    else if (command[0] == "Show")
                    {
                        Console.WriteLine(array[int.Parse(command[1])]);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    countExeptions++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (FormatException)
                {
                    countExeptions++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
            }
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
