using SOLIDExcercise.Report;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExcercise.Appender
{
    public abstract class Appenders : IAppender
    {
        protected Appenders(ILayout layout)
        {
            Layout = layout;
        }

        public ILayout Layout { get; set; }

        public abstract void Append(string date, string error, string message);
    }
}
