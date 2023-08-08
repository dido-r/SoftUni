using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;
        private double modifier = 1;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
            Modifier = modifier;
        }

        private string FlourType 
        {
            get { return flourType; }
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new Exception("Invalid type of dough.");
                }
                flourType = value;
            }
        }
        private string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new Exception("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }

        private double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        private double Modifier
        {
            get { return modifier; }
            set
            {
                if (FlourType.ToLower() == "white")
                {
                    value *= 1.5;
                }
                else if (FlourType.ToLower() == "wholegrain")
                {
                    value *= 1;
                }

                if (BakingTechnique.ToLower() == "crispy")
                {
                    value *= 0.9;
                }
                else if (BakingTechnique.ToLower() == "chewy")
                {
                    value *= 1.1;
                }
                else if (BakingTechnique.ToLower() == "homemade")
                {
                    value *= 1;
                }
                modifier = value;
            }
        }

        public double Calories => 2 * Weight * Modifier;
    }
}
