using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void Test_Phone_Ctor()
        {
            var phone1 = new Smartphone("Nokia", 100);
            Assert.AreEqual("Nokia", phone1.ModelName);
            Assert.AreEqual(100, phone1.MaximumBatteryCharge);
        }

        [Test]
        public void Test_Ctor()
        {
            var shop = new Shop(2);
            Assert.AreEqual(2, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
            Assert.IsInstanceOf<int>(shop.Count);
            Assert.IsInstanceOf<Shop>(shop);
        }

        [Test]
        public void Test_Ctor_Invalid_Capacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var shop = new Shop(-2);
            });
        }

        [Test]
        public void Test_Add()
        {
            var shop = new Shop(2);
            var phone1 = new Smartphone("Nokia", 100);
            var phone2 = new Smartphone("LG", 90);
            shop.Add(phone1);
            Assert.AreEqual(1, shop.Count);
            shop.Add(phone2);
            Assert.AreEqual(2, shop.Count);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone1);
            });
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("Iphone", 100));
            });
        }

        [Test]
        public void Test_Remove()
        {
            var shop = new Shop(2);
            shop.Add(new Smartphone("Nokia", 100));
            shop.Add(new Smartphone("LG", 90));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Samsung");
            });
            shop.Remove("Nokia");
            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void Test_TestPhone()
        {
            var shop = new Shop(2);
            var phone = new Smartphone("Nokia", 100);
            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Samsung", 10);
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Nokia", 120);
            });

            shop.TestPhone("Nokia", 20);
            Assert.AreEqual(80, phone.CurrentBateryCharge);
        }


        [Test]
        public void Test_ChargePhone()
        {
            var shop = new Shop(2);
            var phone1 = new Smartphone("Nokia", 100);
            shop.Add(phone1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("Samsung");
            });

            shop.TestPhone("Nokia", 20);
            shop.ChargePhone("Nokia");
            Assert.AreEqual(100, phone1.CurrentBateryCharge);
        }
    }
}