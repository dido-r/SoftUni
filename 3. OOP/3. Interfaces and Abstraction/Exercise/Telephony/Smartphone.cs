using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        private string number;
        private string site;


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
        public string Site
        {
            get { return site; }
            set
            {
                foreach (char item in value)
                {
                    if (char.IsDigit(item))
                    {
                        throw new ArgumentException("Invalid URL!");
                    }
                }
                site = value;
            }
        }

        public string Browse()
        {
            return $"Browsing: {Site}!";
        }

        public string Call()
        {
            return $"Calling... {Number}";
        }
    }
}
