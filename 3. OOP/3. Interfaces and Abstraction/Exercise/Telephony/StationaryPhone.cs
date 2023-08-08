using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string number;

        public StationaryPhone(string number)
        {
            Number = number;
        }
        public string Number
        {
            get { return number; }
            set
            {
                foreach (char item in value)
                {
                    if (!char.IsDigit(item))
                    {
                        throw new ArgumentException("Invalid number!");
                    }
                }
                number = value;
            }
        }

        public string Call()
        {
            return $"Dialing... {Number}";
        }
    }
}
