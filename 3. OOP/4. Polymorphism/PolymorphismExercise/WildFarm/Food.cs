using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Food
    {
        public Food(string foodType, int quantity)
        {
            FoodType = foodType;
            Quantity = quantity;
        }
        public string FoodType { get; set; }
        public int Quantity { get; private set; }
    }
}
