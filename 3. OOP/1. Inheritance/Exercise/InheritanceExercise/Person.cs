using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public string Name { get; set; }
        public int Age 
        {
            get { return age; }
            set { 
                age = value;
                
                if (age < 0)
                {
                    throw new ArgumentException();
                }
            } 
        }

        public Person(string name, int age) 
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}"; 
        }
    }
}
