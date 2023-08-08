using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<string> stack = new Stack<string>(Create(input));
            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command.StartsWith("Push"))
                {
                    string[] data = command.Split();
                    stack.Push(data[1]);
                }
                else if (command == "Pop")
                {
                    stack.Pop();
                }
                command = Console.ReadLine();
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }

        private static string[] Create(string input)
        {
            input = input.Remove(0, 5);
            var elements = input.Split(", ");
            return elements;
        }
    }
}
