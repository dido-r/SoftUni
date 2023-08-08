using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : IAddable
    {
        private List<string> list = new List<string>();
        public int Add(string input)
        {
            list.Add(input);
            return list.Count - 1;
        }
    }
}
