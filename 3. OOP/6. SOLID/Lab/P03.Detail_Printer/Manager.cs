using P03.Detail_Printer;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : IWorker
    {
        public Manager(string name, ICollection<string> documents)
        {
            Name = name;
            Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public string Name { get; }
        public override string ToString()
        {
            return $"{Name}\n{string.Join(Environment.NewLine, Documents)}";
        }
    }
}
