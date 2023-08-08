using System;
using System.Linq;
using System.Collections.Generic;

namespace LinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            DidoList list = new DidoList();
            //list.AddFirst(new Node (1));
            //list.AddFirst(new Node(2));
            //list.AddFirst(new Node(3));
            //list.AddFirst(new Node(4));

            list.AddLast(new Node(1));
            list.AddLast(new Node(2));
            list.AddLast(new Node(3));
            list.AddLast(new Node(4));
            list.ForEach(x => Console.WriteLine(x.Value));
            Console.WriteLine("Reversed");
            list.Reverse();
            list.ForEach(x => Console.WriteLine(x.Value));
            Console.WriteLine("Reversed");
            list.Reverse();
            list.ForEach(x => Console.WriteLine(x.Value));
            Console.WriteLine("Reversed");
            list.Reverse();
            list.ForEach(x => Console.WriteLine(x.Value));

            //Node node = list.Head;

            //while (node != null)
            //{
            //    Console.WriteLine(node.Value);
            //    node = node.Next;
            //}
        }
    }
}
