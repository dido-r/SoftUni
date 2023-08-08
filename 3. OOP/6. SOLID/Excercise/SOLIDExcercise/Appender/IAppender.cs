using SOLIDExcercise.Report;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExcercise.Appender
{
    public interface IAppender
    {
        void Append(string date, string error, string message);
    }
}
