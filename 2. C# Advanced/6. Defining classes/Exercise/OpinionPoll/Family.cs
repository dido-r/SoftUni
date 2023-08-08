using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            People.Add(member);
        }
        public Person GetOldestMember()
        {
            Person oldest = new Person();
            oldest = People.Find(x => x.Age == People.Max(y => y.Age));
            return oldest;
        }
    }
}
