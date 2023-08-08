using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository test;

    [SetUp]
    public void Test_Initialize()
    {
        test = new HeroRepository();
    }

    [Test]
    public void Test_Ctor()
    {
        Assert.AreEqual(0, test.Heroes.Count);
    }

    [Test]
    public void Test_Create()
    {
        var hero1 = new Hero("Dido", 29);
        var hero2 = new Hero("Test", 42);
        test.Create(hero1);
        test.Create(hero2);
        Assert.AreEqual(2, test.Heroes.Count);
        Assert.IsInstanceOf<string>(test.Create(new Hero("Someone", 62)));
        Assert.AreEqual(3, test.Heroes.Count);
    }

    [Test]
    public void Test_Create_Exceptions()
    {
        test.Create(new Hero("Dido", 29));

        Assert.Throws<InvalidOperationException>(() =>
        {
            test.Create(new Hero("Dido", 29));
        });

        Assert.Throws<ArgumentNullException>(() =>
        {
            test.Create(null);
        });
    }

    [Test]
    public void Test_Remove()
    {
        var hero1 = new Hero("Dido", 29);
        var hero2 = new Hero("Test", 42);
        test.Create(hero1);
        test.Create(hero2);
        test.Remove("Dido");
        Assert.AreEqual(1, test.Heroes.Count);
        Assert.IsFalse(test.Remove("Nqkoi"));
        Assert.IsTrue(test.Remove("Test"));
        Assert.IsInstanceOf<bool>(test.Remove("WASFA"));

        Assert.Throws<ArgumentNullException>(() =>
        {
            test.Remove(null);
        });
    }

    [Test]
    public void Test_GetHeroWithHighestLevel()
    {
        test.Create(new Hero("Dido", 29));
        test.Create(new Hero("Test", 42));

        Assert.IsInstanceOf<Hero>(test.GetHeroWithHighestLevel());
        Assert.AreEqual("Test", test.GetHeroWithHighestLevel().Name);
    }

    [Test]
    public void Test_GetHero()
    {
        test.Create(new Hero("Dido", 29));
        test.Create(new Hero("Test", 42));

        Assert.IsInstanceOf<Hero>(test.GetHero("Dido"));
        Assert.AreEqual("Dido", test.GetHero("Dido").Name);
        Assert.AreEqual(null, test.GetHero("Joro"));
    }
}