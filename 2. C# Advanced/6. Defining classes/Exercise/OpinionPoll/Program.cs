using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            family.People = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                Person person = new Person(data[0], int.Parse(data[1]));
                family.AddMember(person);
            }

            foreach (var someone in family.People.Where(x => x.Age > 30).OrderBy(x => x.Name))
            {
                Console.WriteLine($"{someone.Name} - {someone.Age}");
            }
        }
    }
}
