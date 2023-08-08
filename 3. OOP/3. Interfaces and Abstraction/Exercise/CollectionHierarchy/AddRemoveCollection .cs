using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAddable, Iremovable
    {
        private List<string> list = new List<string>();

        public int Add(string input)
        {
            list.Insert(0, input);
            return 0;
        }

        public string Remove()
        {
            string currentElemnt = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return currentElemnt;
        }
    }
}
