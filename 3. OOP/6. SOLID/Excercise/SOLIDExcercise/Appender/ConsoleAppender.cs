using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExcercise.Appender
{
    public class ConsoleAppender : Appenders
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(string date, string error, string message)
        {
            Console.WriteLine(string.Format(Layout.Format, date, error, message));
        }
    }
}
