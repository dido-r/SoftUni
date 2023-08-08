using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {

            [Test]
            public void Test_Ctor_Correct_Data()
            {
                var garage = new Garage("Test", 4);
                Assert.That(garage.Name == "Test");
                Assert.AreEqual(4, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void Test_Ctor_Invalid_Data()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    var garage = new Garage("", 4);
                });

                Assert.Throws<ArgumentException>(() =>
                {
                    var garage = new Garage("Test", -2);
                });
            }

            [Test]
            [TestCaseSource("Initialize")]
            public void Test_Add(Car[] car, int count)
            {
                var garage = new Garage("Test", 4);

                foreach (var item in car)
                {
                    garage.AddCar(item);
                }
                Assert.AreEqual(count, garage.CarsInGarage);
            }

            public static IEnumerable<TestCaseData> Initialize()
            {
                yield return new TestCaseData(new Car[]
                {
                new Car("Toyota", 2),
                new Car("BMW", 2)
                }, 2);

                yield return new TestCaseData(new Car[]
                {
                new Car("Toyota", 2),
                new Car("BMW", 2),
                new Car("Audi", 2),
                new Car("Skoda", 2),
                }, 4);
            }

            [Test]
            public void Test_Add_Invalid()
            {
                var garage = new Garage("Test", 2);
                garage.AddCar(new Car("Skoda", 1));
                garage.AddCar(new Car("BMW", 1));

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(new Car("Audi", 2));
                });
            }

            [Test]
            public void Test_FixCar()
            {
                var garage = new Garage("Test", 4);
                var car = new Car("Toyota", 2);
                garage.AddCar(car);
                garage.FixCar("Toyota");
                Assert.AreEqual(0, car.NumberOfIssues);
                Assert.That(car.IsFixed == true);
            }

            [Test]
            public void Test_FixCar_Type()
            {
                var garage = new Garage("Test", 4);
                var car = new Car("Toyota", 2);
                garage.AddCar(car);
                Assert.IsInstanceOf<Car>(garage.FixCar("Toyota"));
            }

            [Test]
            public void Test_FixCar_Invalid()
            {
                var garage = new Garage("Test", 4);
                garage.AddCar(new Car("Toyota", 2));

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("BMW");
                });
            }

            [Test]
            public void Test_RemoveFixedCar_Count()
            {
                var garage = new Garage("Test", 4);
                garage.AddCar(new Car("Toyota", 0));
                garage.AddCar(new Car("BMW", 0));

                Assert.AreEqual(2, garage.RemoveFixedCar());
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void Test_RemoveFixedCar_Type()
            {
                var garage = new Garage("Test", 4);
                garage.AddCar(new Car("Toyota", 0));
                garage.AddCar(new Car("BMW", 0));

                Assert.IsInstanceOf<int>(garage.RemoveFixedCar());
            }

            [Test]
            public void Test_RemoveFixedCar_Invalid_Car()
            {
                var garage = new Garage("Test", 4);
                garage.AddCar(new Car("Toyota", 1));
                garage.AddCar(new Car("BMW", 1));

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                });
            }

            [Test]
            public void Test_Report_Text()
            {
                var garage = new Garage("Test", 4);
                garage.AddCar(new Car("Toyota", 1));
                garage.AddCar(new Car("BMW", 1));

                Assert.AreEqual("There are 2 which are not fixed: Toyota, BMW.", garage.Report());
            }

            [Test]
            public void Test_Report_Type()
            {
                var garage = new Garage("Test", 4);
                garage.AddCar(new Car("Toyota", 1));
                garage.AddCar(new Car("BMW", 1));

                Assert.IsInstanceOf<string>(garage.Report());
            }
        }
    }
}