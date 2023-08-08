using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double weight;
        private double modifier = 1;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
            Modifier = modifier;
        }

        private string Type
        {
            get { return type; }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }
        private double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{Type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }
        private double Modifier 
        {
            get { return modifier; }
            set
            {
                if (Type.ToLower() == "meat")
                {
                    value *= 1.2;
                }
                else if (Type.ToLower() == "veggies")
                {
                    value *= 0.8;
                }
                else if (Type.ToLower() == "cheese")
                {
                    value *= 1.1;
                }
                else if (Type.ToLower() == "sauce")
                {
                    value *= 0.9;
                }
                modifier = value;
            }
        }
        public double Calories => 2 * Weight * Modifier;
    }
}
