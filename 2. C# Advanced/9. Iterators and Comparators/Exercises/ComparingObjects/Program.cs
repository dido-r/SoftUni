using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Person> list = new List<Person>();

            while (input != "END")
            {
                string[] data = input.Split();
                list.Add(new Person(data[0], int.Parse(data[1]), data[2]));
                input = Console.ReadLine();
            }
            var person = list[int.Parse(Console.ReadLine()) - 1];
            int matchCount = -1;

            foreach (var guy in list)
            {
                if (guy.CompareTo(person) == 0)
                {
                    matchCount++;
                }
            }

            if (matchCount == 0)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{++matchCount} {list.Count - matchCount} {list.Count}");
            }
        }
    }
}
