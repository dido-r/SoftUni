using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            List<string> filters = new List<string>();
            string command = Console.ReadLine();

            while (command != "Print")
            {
                string[] data = command.Split(";");

                if (data[0].StartsWith("Add"))
                {
                    filters.Add(data[1] + "/" + data[2]);
                }
                else if (data[0].StartsWith("Remove"))
                {
                    filters.Remove(data[1] + "/" + data[2]);
                }
                command = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                string criteria = filter.Split("/")[0];
                string value = filter.Split("/")[1];
                Func<List<string>, string, List< string >> result = Filtered(criteria, value);
                names = result(names, value).ToList();
            }
            Console.WriteLine(string.Join(" ", names));
        }

        private static Func<List<string>, string, List<string>> Filtered(string criteria, string value)
        {
            if (criteria.StartsWith("Starts"))
            {
                return (x, y) => x.Where(c => !c.StartsWith(y)).ToList();
            }
            else if (criteria.StartsWith("Ends"))
            {
                return (x, y) => x.Where(c => !c.EndsWith(y)).ToList();
            }
            else if (criteria.StartsWith("Length"))
            {
                return (x, y) => x.Where(c => c.Length != int.Parse(y)).ToList();
            }
            else
            {
                return (x, y) => x.Where(c => !c.Contains(y)).ToList();
            }
        }
    }
}
