using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Repair
    {
        public Repair(string part, int hour)
        {
            PartName = part;
            HoursWorked = hour;
        }
        public string PartName { get; set; }
        public int HoursWorked { get; set; }

        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {HoursWorked}";
        }
    }
}
