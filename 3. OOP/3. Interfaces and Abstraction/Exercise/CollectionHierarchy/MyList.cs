using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : IAddable, Iremovable
    {
        private List<string> list = new List<string>();

        public int Used => list.Count;
        public int Add(string input)
        {
            list.Insert(0, input);
            return 0;
        }

        public string Remove()
        {
            string currentElemnt = list[0];
            list.RemoveAt(0);
            return currentElemnt;
        }
    }
}
