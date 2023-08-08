using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        [TestCase("Test", 10)]
        [TestCase("Sila", 25)]
        public void Test_Gym_Ctor_With_Valid_Data(string name, int size)
        {
            Gym gym = new Gym(name, size);
            Assert.That(name == gym.Name);
            Assert.AreEqual(size, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        [TestCase("", 10)]
        [TestCase(null, 10)]
        public void Test_Gym_Ctor_With_Invalid_Name(string name, int size)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, size);
            });
        }

        [Test]
        [TestCase("Test", -2)]
        [TestCase("Test", -597)]
        public void Test_Gym_Ctor_With_Invalid_Size(string name, int size)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym(name, size);
            });
        }

        [Test]
        public void Test_Gym_AddAthlete()
        {
            Gym gym = new Gym("Test", 4);
            gym.AddAthlete(new Athlete("Pesho"));
            gym.AddAthlete(new Athlete("Dido"));
            Assert.AreEqual(2, gym.Count);
            gym.AddAthlete(new Athlete("Ivo"));
            gym.AddAthlete(new Athlete("Gosho"));
            Assert.AreEqual(4, gym.Count);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(new Athlete("Mitko"));
            });
        }

        [Test]
        public void Test_Gym_RemoveAthlete()
        {
            Gym gym = new Gym("Test", 2);
            gym.AddAthlete(new Athlete("Pesho"));
            gym.AddAthlete(new Athlete("Dido"));
            gym.RemoveAthlete("Dido");
            Assert.AreEqual(1, gym.Count);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Gosho");
            });
        }

        [Test]
        public void Test_Gym_InjureAthlete()
        {
            Gym gym = new Gym("Test", 2);
            Athlete athlete = new Athlete("Dido");
            gym.AddAthlete(athlete);
            Assert.AreEqual(false, athlete.IsInjured);
            gym.InjureAthlete("Dido");
            Assert.AreEqual(true, athlete.IsInjured);
            Assert.IsInstanceOf<Athlete>(gym.InjureAthlete("Dido"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Gosho");
            });
        }

        [Test]
        public void Test_Gym_Report()
        {
            Gym gym = new Gym("Test", 2);
            gym.AddAthlete(new Athlete("Dido"));
            gym.AddAthlete(new Athlete("Ivo"));
            Assert.AreEqual("Active athletes at Test: Dido, Ivo", gym.Report());
            Assert.IsInstanceOf<string>(gym.Report());
        }

        [Test]
        public void Test_Athlete()
        {
            var athlete = new Athlete("Dido");
            Assert.AreEqual("Dido", athlete.FullName);
            Assert.AreEqual(false, athlete.IsInjured);
        }
    }
}
