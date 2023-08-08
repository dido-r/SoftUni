using SOLIDExcercise.LogFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLIDExcercise.Appender
{
    public class FileAppender : Appenders
    {
        public FileAppender(ILayout layout, LogFile file) : base(layout)
        {
            LogFile = file;
        }

        public LogFile LogFile { get; }

        public override void Append(string date, string error, string message)
        {
            LogFile.Write(string.Format(Layout.Format, date, error, message));
            File.AppendAllText("../../../log.txt", string.Format(Layout.Format, date, error, message) + Environment.NewLine);
        }
    }
}
