using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Coffee : HotBeverage
    {
        public double Caffeine { get; set; }
        public Coffee(string name, double caffeine) : base(name, 3.50m, 50)
        {
            Caffeine = caffeine;
        }
    }
}
