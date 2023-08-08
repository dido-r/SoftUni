using System;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection AddRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                Console.Write(addCollection.Add(item) + " ");
            }
            Console.WriteLine();
            foreach (var item in input)
            {
                Console.Write(AddRemoveCollection.Add(item) + " ");
            }
            Console.WriteLine();
            foreach (var item in input)
            {
                Console.Write(myList.Add(item) + " ");
            }
            Console.WriteLine();

            int removeCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < removeCount; i++)
            {
                Console.Write(AddRemoveCollection.Remove() + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < removeCount; i++)
            {
                Console.Write(myList.Remove() + " ");
            }
        }
    }
}
