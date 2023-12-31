﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public List<Car> Cars { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Cars.Count; } set { } }

        public Parking(int capacity)
        {
            Cars = new List<Car>();
            Capacity = capacity;
        }

        public string AddCar(Car car)
        {
            if (Cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (Cars.Count == Capacity)
            {
                return "Parking is full!";
            }
            Cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }
        public string RemoveCar(string registrationNumber)
        {
            if (!Cars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exists!";
            }
            Cars.Remove(Cars.First(x => x.RegistrationNumber == registrationNumber));
            return $"Successfully removed {registrationNumber}";
        }
        public Car GetCar(string registrationNumber)
        {
            return Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var item in registrationNumbers)
            {
                if (Cars.Any(x => x.RegistrationNumber == item))
                {
                    Cars.Remove(Cars.First(x => x.RegistrationNumber == item));
                }
            }
        }
    }
}
