using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLIDExcercise.LogFiles
{
    public class LogFile : ILogFile
    {
        private StringBuilder sb;
        public LogFile()
        {
            sb = new StringBuilder();
        }

        public int Size => sb.ToString().Where(char.IsLetter).Sum(x => x);

        public void Write(string message) => sb.Append(message);
    }
}
