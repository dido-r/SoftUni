using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] pizzaData = Console.ReadLine().Split();

            try
            {
                Pizza pizza = new Pizza(pizzaData[1]);
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    Dough dough = new Dough(data[1], data[2], double.Parse(data[3]));
                    pizza.Dought = dough;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    return;
                }

                string input = Console.ReadLine();

                while (input != "END")
                {
                    string[] toppingData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        Topping topping = new Topping(toppingData[1], double.Parse(toppingData[2]));
                        pizza.AddTopping(topping);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                        return;
                    }
                    input = Console.ReadLine();
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }
        }
    }
}
