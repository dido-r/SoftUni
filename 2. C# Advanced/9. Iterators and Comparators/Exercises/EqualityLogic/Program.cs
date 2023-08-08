using System;
using System.Linq;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<Person> hashSet = new HashSet<Person>();
            SortedSet<Person> sortedSet = new SortedSet<Person>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] data = input.Split();
                var person = new Person(data[0], int.Parse(data[1]));
                hashSet.Add(new Person(data[0], int.Parse(data[1])));
                sortedSet.Add(new Person(data[0], int.Parse(data[1])));
            }
            Console.WriteLine(hashSet.Count);
            Console.WriteLine(sortedSet.Count);
        }
    }
}
