using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission
    {
        private string state;

        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }
        public string CodeName { get; set; }
        public string State { get; set; }

        public void CompleteMission()
        {
            if (State == "inProgress")
            {
                State = "Finished";
            }
        }
        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
