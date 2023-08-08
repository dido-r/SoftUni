using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExcercise.Layouts
{
    public class SimpleLayout : Layout
    {
        private static string simpleFormat => "{0} - {1} - {2}";

        public SimpleLayout() : base(simpleFormat)
        {
        }
    }
}
