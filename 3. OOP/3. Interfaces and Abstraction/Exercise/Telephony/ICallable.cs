using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ICallable
    {
        public string Number { get; set; }
        public string Call();
    }
}
