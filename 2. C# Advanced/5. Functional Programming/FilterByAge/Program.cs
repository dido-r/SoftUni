using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> list = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(",");
                Student student = new Student();
                student.Name = input[0];
                student.Age = int.Parse(input[1]);
                list.Add(student);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            Func<Student, int, bool> filter = AgeFilter(condition);
            string format = Console.ReadLine();
            Action<Student> print = Print(format);

            list = list.Where(x => filter(x, age)).ToList();

            foreach (var student in list)
            {
                print(student);
            }
        }

        private static Action<Student> Print(string format)
        {
            if (format == "name")
            {
                return x => Console.WriteLine(x.Name);
            }
            else if (format == "age")
            {
                return x => Console.WriteLine(x.Age);
            }
            else if (format == "name age")
            {
                return x => Console.WriteLine($"{x.Name} - {x.Age}");
            }
            return null;
        }

        private static Func<Student, int, bool> AgeFilter(string condition)
        {
            if (condition == "younger")
            {
                return (x, age) => x.Age < age;
            }
            else if (condition == "older")
            {
                return (x, age) => x.Age >= age;
            }
            return null;
        }
    }
}
