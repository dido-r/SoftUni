using SOLIDExcercise.Appender;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExcercise.Loggers
{
    public interface ILogger
    {
        IAppender[] Appenders { get; }
        void Info(string date, string message);
        void Warning(string date, string message);
        void Error(string date, string message);
        void Critical(string date, string message);
        void Fatal(string date, string message);
    }
}
