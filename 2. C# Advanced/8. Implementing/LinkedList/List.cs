using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class DidoList
    {
        public bool isReversed = false;
        public Node Head { get; set; }
        public Node Tail { get; set; }


        public void AddFirst(Node element)
        {
            if (Head == null)
            {
                Head = element;
                Tail = element;
            }
            else
            {
                var prevHead = Head;
                Head = element;
                prevHead.Previous = Head;
                Head.Next = prevHead;
            }
        }
        public void AddLast(Node element)
        {
            if (Head == null)
            {
                Head = element;
                Tail = element;
            }
            else
            {
                var prevTail = Tail;
                Tail = element;
                prevTail.Next = Tail;
                Tail.Previous = prevTail;
            }
        }
        public void RemoveFirst()
        {
            var node = Head;
            if (node.Next != null)
            {
                Head = node.Next;
                Head.Previous = null;
            }
            else
            {
                Console.WriteLine("Only one element left!");
            }
        }
        public void RemoveLast()
        {
            var node = Tail;
            if (node.Previous != null)
            {
                Tail = node.Previous;
                Tail.Next = null;
            }
            else
            {
                Console.WriteLine("Only one element left!");
            }
        }
        public void ForEach(Action<Node> action)
        {
            var currentNode = Head;
            if (isReversed)
            {
                currentNode = Tail;
            }
            while (currentNode != null)
            {
                action(currentNode);
                if (isReversed)
                {
                    currentNode = currentNode.Previous;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }
        }

        public void Reverse()
        {
            isReversed = !isReversed;
        }
    }
}
