using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity) { }

        public override void Drive(double distance)
        {
            if (FuelQuantity >= (FuelConsumption + 0.9) * distance)
            {
                FuelQuantity -= (FuelConsumption + 0.9) * distance;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                if (FuelQuantity + liters <= TankCapacity)
                {
                    FuelQuantity += liters;
                }
                else
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
            }
        }
    }
}
