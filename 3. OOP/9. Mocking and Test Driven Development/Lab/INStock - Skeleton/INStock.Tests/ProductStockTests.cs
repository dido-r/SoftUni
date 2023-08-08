namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class ProductStockTests
    {
        private IProductStock stock;
        private IProduct product1;
        private IProduct product2;
        private IProduct product3;
        private IProduct product4 = new Product("Veggies", 2m, 30);
        private IProduct product5 = new Product("Soda", 0.9m, 2);
        private IProduct product6 = new Product("Water", 1m, 9);

        [SetUp]
        public void SetUp()
        {
            stock = new ProductStock();
            product1 = new Product("Cola", 1.5m, 20);
            product2 = new Product("Pepsi", 1.5m, 20);
            product3 = new Product("Meat", 8.5m, 10);
            stock.Add(product1);
            stock.Add(product2);
            stock.Add(product3);
        }


        [Test]
        public void Test_Add_Method()
        {
            Assert.AreEqual(3, stock.Count);
        }

        [Test]
        public void Test_Contains_Method()
        {
            Assert.IsInstanceOf<bool>(stock.Contains(product2));
        }

        [Test]
        public void Test_Find_Method_With_Negative_OutOfRange_Index()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                stock.Find(-2);
            });
        }

        [Test]
        public void Test_Find_Method_With_Correct_Index()
        {
            Assert.AreEqual(product2, stock.Find(1));
            Assert.IsInstanceOf<IProduct>(stock.Find(1));
        }

        [Test]
        [TestCase(1.5)]
        [TestCase(8.5)]
        [TestCase(2)]
        public void Test_FindAllByPrice_Method(double price)
        {
            Assert.IsInstanceOf<IEnumerable<IProduct>>(stock.FindAllByPrice(price));
        }

        [Test]
        [TestCase(20)]
        [TestCase(10)]
        [TestCase(2)]
        public void Test_FindAllByQuantity_Method(int quantity)
        {
            Assert.IsInstanceOf<IEnumerable<IProduct>>(stock.FindAllByPrice(quantity));
        }

        [Test]
        [TestCase(0.5, 20)]
        [TestCase(5, 10)]
        [TestCase(0.2, 0.9)]
        [TestCase(50, 60)]
        public void Test_FindAllInRange_Method(double lo, double hi)
        {
            stock.Add(product4);
            stock.Add(product5);
            stock.Add(product6);

            Assert.IsInstanceOf<IEnumerable<IProduct>>(stock.FindAllInRange(lo, hi));
        }

        [Test]
        [TestCase("Cola")]
        [TestCase("Pepsi")]
        [TestCase("Meat")]
        public void Test_FindByLabel_Method_With_Match(string label)
        {
            stock.Add(product4);
            stock.Add(product5);
            stock.Add(product6);

            Assert.IsInstanceOf<IProduct>(stock.FindByLabel(label));
        }

        [Test]
        [TestCase("Drugo")]
        [TestCase("Nqma go")]
        [TestCase("Test")]
        public void Test_FindByLabel_Method_With_No_Match(string label)
        {
            stock.Add(product4);
            stock.Add(product5);
            stock.Add(product6);

            Assert.Throws<ArgumentException>(() =>
            {
                stock.FindByLabel(label);
            });
        }

        [Test]
        public void Test_FindMostExpensiveProduct()
        {
            Assert.IsInstanceOf<IProduct>(stock.FindMostExpensiveProduct());
        }

        [Test]
        public void Test_GetEnumerator()
        {
            Assert.IsInstanceOf<IEnumerator<IProduct>>(stock.GetEnumerator());
        }

        [Test]
        public void Test_Remove_Is_Bool()
        {
            Assert.IsInstanceOf<bool>(stock.Remove(product2));
            Assert.IsInstanceOf<bool>(stock.Remove(new Product("Test", 1.7m, 20)));
        }

        [Test]
        public void Test_Remove_Method()
        {
            stock.Remove(product2);
            Assert.AreEqual(2, stock.Count);
        }
    }
}
