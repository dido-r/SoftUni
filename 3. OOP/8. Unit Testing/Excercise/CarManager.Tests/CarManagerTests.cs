namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        [TestCase("Audi", "A4", 5.5, 50)]
        [TestCase("BMW", "3", 6.5, 40.2)]
        [TestCase("VW", "Arteon", 4.5, 60)]
        public void Test_Constructor_With_Valid_Input(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase("", "A4", 5.5, 50)]
        [TestCase(null, "3", 6.5, 40.2)]
        [TestCase("VW", "", 4.5, 60)]
        [TestCase("VW", null, 4.5, 60)]
        [TestCase("VW", "Golf", 0, 60)]
        [TestCase("VW", "Golf", -2, 60)]
        [TestCase("VW", "Golf", 4.5, 0)]
        [TestCase("VW", "Golf", 4.5, -2)]
        public void Test_Constructor_With_Invalid_Input(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        [TestCase(45)]
        [TestCase(10)]
        public void Test_If_Refuel_Change_RefuelAmaunt_Of_Empty_Tank(double fuel)
        {
            Car car = new Car("Audi", "A4", 5.5, 50);
            car.Refuel(fuel);
            Assert.AreEqual(fuel, car.FuelAmount);
        }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        [TestCase(45)]
        public void Test_Refuel_When_Goes_To_Full_Capacity(double fuel)
        {
            Car car = new Car("Audi", "A4", 5.5, 50);
            car.Refuel(30);
            car.Refuel(fuel);
            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [Test]
        [TestCase(-20)]
        [TestCase(0)]
        public void Test_If_Refuel_Throw_Exception_For_Negative_Amount_Of_Fuel(double fuel)
        {
            Car car = new Car("Audi", "A4", 5.5, 50);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuel);
            }, "Fuel amount cannot be zero or negative!");
        }

        [Test]
        [TestCase(500)]
        [TestCase(600)]
        [TestCase(700)]
        public void Test_If_Drive_Throw_Exception(double distance)
        {
            Car car = new Car("Audi", "A4", 5.5, 20);
            car.Refuel(20);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            }, "You don't have enough fuel to drive!");
        }

        [Test]
        [TestCase(500)]
        [TestCase(400)]
        [TestCase(300)]
        public void Test_If_Drive_Change_FuelAmount(double distance)
        {
            Car car = new Car("Audi", "A4", 5.5, 50);
            car.Refuel(50);
            car.Drive(distance);
            Assert.IsTrue(car.FuelAmount < 50);
        }
    }
}