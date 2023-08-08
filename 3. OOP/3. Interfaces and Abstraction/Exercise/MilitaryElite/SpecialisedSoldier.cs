using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class SpecialisedSoldier : Private
    {
        private string corps;
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public string Corps
        {
            get { return corps; }
            set 
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException();
                }
                corps = value; 
            }
        }
    }
}
