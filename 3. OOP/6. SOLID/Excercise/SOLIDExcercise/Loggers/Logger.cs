using SOLIDExcercise.Appender;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExcercise.Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appender)
        {
            Appenders = appender;
        }

        public IAppender[] Appenders { get; }

        public void Info(string date, string message)
        {
            Log(date, "Info", message);
        }

        public void Warning(string date, string message)
        {
            Log(date, "Warning", message);
        }
        public void Error(string date, string message)
        {
            Log(date, "Error", message);
        }
        public void Critical(string date, string message)
        {
            Log(date, "Critical", message);
        }
        public void Fatal(string date, string message)
        {
            Log(date, "Fatal", message);
        }

        private void Log(string date, string level, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(date, level, message);
            }
        }
    }
}
