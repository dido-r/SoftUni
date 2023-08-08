using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class Spy : Soldier, ISoldier
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}\nCode Number: {CodeNumber}";
        }
    }
}
