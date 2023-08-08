using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class Commando : SpecialisedSoldier, ISoldier
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps, string[] data) : base(id, firstName, lastName, salary, corps)
        {
            Missions = new List<Mission>();

            for (int i = 0; i < data.Length; i += 2)
            {
                if (data[i + 1] == "inProgress" || data[i + 1] == "Finished")
                {
                    Missions.Add(new Mission(data[i], data[i + 1]));
                }
            }
        }
        public List<Mission> Missions { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");

            foreach (var item in Missions)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().Trim();
        }
    }
}
