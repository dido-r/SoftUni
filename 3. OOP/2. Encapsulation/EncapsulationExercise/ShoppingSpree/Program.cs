using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> listOfPeople = new List<Person>();

            foreach (var item in people)
            {
                string[] data = item.Split("=", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    var person = new Person(data[0], decimal.Parse(data[1]));
                    listOfPeople.Add(person);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    return;
                }
            }

            string[] goods = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Product> listOfGoods = new List<Product>();

            foreach (var item in goods)
            {
                try
                {
                    string[] data = item.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    var good = new Product(data[0], decimal.Parse(data[1]));
                    listOfGoods.Add(good);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    return;
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var currentPerson = listOfPeople.First(x => x.Name == data[0]);
                var currentProduct = listOfGoods.First(x => x.Name == data[1]);
                currentPerson.AddProduct(currentProduct);
                input = Console.ReadLine();
            }

            foreach (var person in listOfPeople)
            {
                Console.Write($"{person.Name} - ");

                if (person.BagOfProducts.Count == 0)
                {
                    Console.WriteLine("Nothing bought");
                }
                else
                {
                    Console.WriteLine(string.Join(", ", person.BagOfProducts.Select(x => x.Name)));
                }
            }
        }
    }
}
