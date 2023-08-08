using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class Engineer : SpecialisedSoldier, ISoldier
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps, string[] data) : base(id, firstName, lastName, salary, corps)
        {
            Repairs = new List<Repair>();

            for (int i = 0; i < data.Length; i += 2)
            {
                Repairs.Add(new Repair(data[i], int.Parse(data[i + 1])));
            }
        }
        public List<Repair> Repairs { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Repairs:");

            foreach (var item in Repairs)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().Trim();
        }
    }
}
