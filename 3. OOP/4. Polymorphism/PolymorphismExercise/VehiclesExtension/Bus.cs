using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity) { }

        public override void Drive(double distance)
        {
            if (FuelQuantity >= (FuelConsumption + 1.4) * distance)
            {
                FuelQuantity -= (FuelConsumption + 1.4) * distance;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public void DriveEmpty(double distance)
        {
            if (FuelQuantity >= FuelConsumption * distance)
            {
                FuelQuantity -= FuelConsumption * distance;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
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
