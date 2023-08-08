using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class LieutenantGeneral : Private
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            SetOfPrivates = new List<ISoldier>();
        }
        public List<ISoldier> SetOfPrivates { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine("Privates:");

            foreach (var item in SetOfPrivates)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().Trim();
        }
    }
}
