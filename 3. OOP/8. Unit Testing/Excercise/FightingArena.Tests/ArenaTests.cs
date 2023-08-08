namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void Test_Ctor()
        {
            Arena arena = new Arena();
            Assert.AreEqual(0, arena.Count);
            Assert.AreEqual(0, arena.Warriors.Count);
        }

        [Test]
        public void Test_If_Enroll_Works_With_Valid_Data()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("BK", 20, 150));
            arena.Enroll(new Warrior("SM", 20, 150));
            Assert.AreEqual(2, arena.Count);
            Assert.AreEqual(2, arena.Warriors.Count);
        }

        [Test]
        public void Test_How_Enroll_Works_With_Invalid_Data()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("BK", 20, 150));
            arena.Enroll(new Warrior("SM", 20, 150));
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(new Warrior("BK", 30, 200));
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        [TestCase("BladeKnight", "DarkLord")]
        [TestCase("MagicGladiator", "SoulMaster")]
        [TestCase("MagicGladiator", "DarkWizard")]
        public void Test_How_Fightl_Works_With_Invlid_Data(string attackerName, string defenderName)
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("BladeKnight", 20, 150));
            arena.Enroll(new Warrior("SoulMaster", 20, 150));

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attackerName, defenderName);
            }, "There is no fighter with such name enrolled for the fights!");
        }
    }
}
