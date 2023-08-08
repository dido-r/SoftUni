using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public double DaysBetween { get; set; }
        public static double DaysCalcule(string firstDate, string secondDate)
        {
            var first = DateTime.Parse(firstDate);
            var second = DateTime.Parse(secondDate);
            return Math.Abs((first - second).TotalDays);
        }
    }
}
