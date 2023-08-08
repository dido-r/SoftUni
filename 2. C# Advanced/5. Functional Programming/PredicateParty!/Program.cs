using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();

            string command = Console.ReadLine();
            Func<List<string>, string, List<string>> start = (x, y) => x.Where(z => z.StartsWith(y)).ToList();
            Func<List<string>, string, List<string>> end = (x, y) => x.Where(z => z.EndsWith(y)).ToList();
            Func<List<string>, int, List<string>> len = (x, y) => x.FindAll(z => z.Length == y).ToList();

            while (command != "Party!")
            {
                string[] info = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string criteria = info[1];
                string value = info[2];

                switch (info[0])
                {
                    case "Remove":
                        people.RemoveAll(Filtered(criteria, value));
                        break;
                    case "Double":
                        var list = people.FindAll(Filtered(criteria, value));
                        var index = people.FindIndex(Filtered(criteria, value));
                        if (index == -1)
                        {
                            command = Console.ReadLine();
                            continue;
                        }
                        people.InsertRange(index, list);
                        break;
                }
                command = Console.ReadLine();
            }

            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(String.Join(", ", people) + " are going to the party!");
            }
        }

        private static Predicate<string> Filtered(string criteria, string value)
        {
            if (criteria == "StartsWith")
            {
                return x => x.StartsWith(value);
            }
            else if (criteria == "EndsWith")
            {
                return x => x.EndsWith(value);
            }
            else
            {
                return x => x.Length == int.Parse(value);
            }
        }
    }
}
