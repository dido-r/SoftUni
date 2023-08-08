using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private double totalCalories;

        public Pizza(string name)
        {
            Name = name;
            Topping = new List<Topping>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dought { get; set; }
        private List<Topping> Topping { get; set; }
        public int NumberOfToppings { get { return Topping.Count; } }
        public double TotalCalories { get { return CalculateCalories(); } }

        public void AddTopping(Topping top)
        {
            if (Topping.Count == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            Topping.Add(top);
        }

        public double CalculateCalories()
        {
            totalCalories += Dought.Calories;

            foreach (var item in Topping)
            {
                totalCalories += item.Calories;
            }
            return totalCalories;
        }
    }
}
