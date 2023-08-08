namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        [TestCase("DarkKnight", 10, 100)]
        [TestCase("BladeKnight", 15, 150)]
        [TestCase("BladeMaster", 20, 200)]
        public void Test_Constructor_With_Valid_Input(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        [TestCase("", 10, 100)]
        [TestCase(" ", 15, 150)]
        [TestCase(null, 20, 200)]
        [TestCase("DarkKnight", 0, 200)]
        [TestCase("DarkKnight", -20, 200)]
        [TestCase("DarkKnight", 20, -2)]
        [TestCase("", -5, -1)]
        public void Test_Constructor_With_Invalid_Input(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [Test]
        [TestCase("DarkKnight", 20, 25, "DarkLord", 30, 200)]
        [TestCase("DarkKnight", 20, 30, "DarkLord", 30, 200)]
        [TestCase("DarkKnight", 20, 200, "DarkLord", 30, 25)]
        [TestCase("DarkKnight", 20, 200, "DarkLord", 30, 30)]
        [TestCase("DarkKnight", 20, 50, "DarkLord", 130, 100)]
        public void Test_If_Attack_Throws_Exception(string name, int damage, int hp, string nameEnemy, int damageEnemy, int hpEnemy)
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Warrior enemy = new Warrior(nameEnemy, damageEnemy, hpEnemy);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(enemy);
            });
        }

        [Test]
        [TestCase("DarkKnight", 20, 200, "DarkLord", 30, 200)]
        [TestCase("DarkKnight", 20, 200, "DarkLord", 30, 100)]
        [TestCase("DarkKnight", 20, 200, "DarkLord", 30, 50)]
        public void Test_If_Attack_Takes_EnemyHP(string name, int damage, int hp, string nameEnemy, int damageEnemy, int hpEnemy)
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Warrior enemy = new Warrior(nameEnemy, damageEnemy, hpEnemy);
            warrior.Attack(enemy);
            Assert.IsTrue(enemy.HP < hpEnemy);
        }

        [Test]
        [TestCase("DarkKnight", 50, 200, "DarkLord", 30, 50)]
        [TestCase("DarkKnight", 70, 200, "DarkLord", 30, 40)]
        [TestCase("DarkKnight", 100, 200, "DarkLord", 30, 35)]
        public void Test_If_Attack_Enemy_Is_Dead(string name, int damage, int hp, string nameEnemy, int damageEnemy, int hpEnemy)
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Warrior enemy = new Warrior(nameEnemy, damageEnemy, hpEnemy);
            warrior.Attack(enemy);
            Assert.AreEqual(0, enemy.HP);
        }

        [Test]
        [TestCase("DarkKnight", 50, 200, "DarkLord", 30, 100)]
        [TestCase("DarkKnight", 70, 150, "DarkLord", 40, 150)]
        [TestCase("DarkKnight", 100, 100, "DarkLord", 50, 200)]
        public void Test_If_Enemy_Attack_Takes_HP(string name, int damage, int hp, string nameEnemy, int damageEnemy, int hpEnemy)
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Warrior enemy = new Warrior(nameEnemy, damageEnemy, hpEnemy);
            warrior.Attack(enemy);
            Assert.IsTrue(warrior.HP < hp);
        }
    }
}