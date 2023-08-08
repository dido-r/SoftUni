//namespace INStock.Tests
//{
//    using System;
//    using INStock.Contracts;
//    using NUnit.Framework;

//    public class ProductTests
//    {
//        [Test]
//        [TestCase("Cola", 1.5, 20)]
//        [TestCase("Meat", 8.5, 10)]
//        [TestCase("Veggies", 2, 30)]
//        public void Test_Constructor(string label, decimal price, int quantity)
//        {
//            IProduct product = new Product(label, price, quantity);
//            Assert.AreEqual(label, product.Label);
//            Assert.AreEqual(price, product.Price);
//            Assert.AreEqual(quantity, product.Quantity);
//        }

//        [Test]
//        [TestCase("Cola", 1.5, 20, "Soda", 0.9, 2)]
//        [TestCase("Meat", 8.5, 10, "Meat", 1.5, 5)]
//        [TestCase("Veggies", 2, 15, "Veggies", 2, 8)]
//        public void Test_Compare_Method(string label, decimal price, int quantity, string label2, decimal price2, int quantity2)
//        {
//            IProduct product1 = new Product(label, price, quantity);
//            IProduct product2 = new Product(label2, price2, quantity2);
//            var result = product1.CompareTo(product2);
//            Assert.IsAssignableFrom<int>(result);
//        }
//    }
//}