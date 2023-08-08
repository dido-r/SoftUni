using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity) { }

        public override void Drive(double distance)
        {
            if (FuelQuantity >= (FuelConsumption + 1.6) * distance)
            {
                FuelQuantity -= (FuelConsumption + 1.6) * distance;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
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
                if (FuelQuantity + (liters * 0.95) <= TankCapacity)
                {
                    FuelQuantity += (liters * 0.95);
                }
                else
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
            }
        }
    }
}
