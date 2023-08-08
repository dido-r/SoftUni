using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExcercise.Layouts
{
    public class XmlLayout : Layout
    {
        private static string xmlFormat => @"<log>
    <date>{0}</date>
    <level>{1}</level>
    <message>{2}</message>
</log>";

        public XmlLayout() : base(xmlFormat)
        {
        }
    }
}
