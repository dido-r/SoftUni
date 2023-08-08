namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database data;

        [Test]
        [TestCase(1111, "Vasko")]
        [TestCase(2222, "Mitko")]
        public void Test_Person_Constructor(long id, string name)
        {
            Person person = new Person(id, name);
            Assert.AreEqual(id, person.Id);
            Assert.AreEqual(name, person.UserName);
        }

        [Test]
        [TestCaseSource("Initialize")]
        public void Test_Database_Constructor(Person[] persons, int count)
        {
            data = new Database(persons);
            Assert.AreEqual(count, data.Count);
        }

        public static IEnumerable<TestCaseData> Initialize()
        {
            yield return new TestCaseData(new Person[]
            {
                new Person(1111, "Dido"),
                new Person(2222, "Ivo")
            }, 2);

            yield return new TestCaseData(new Person[]
            {
                new Person(1111, "Dido"),
                new Person(2222, "Ivo"),
                new Person(4444, "Dimitrichko"),
                new Person(5555, "Viktor"),
            }, 4);
        }
        [Test]
        public void Test_Database_Constructor_When_Add_More_Than_16_Persons_Throw_Exception()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                data = new Database(

                    new Person(1111, "Dido"),
                    new Person(2222, "Ivo"),
                    new Person(3333, "Pesho"),
                    new Person(4444, "Dimitrichko"),
                    new Person(5555, "Viktor"),
                    new Person(6666, "Nqkoi"),
                    new Person(7777, "Drug"),
                    new Person(8888, "Gosho"),
                    new Person(9999, "Tedo"),
                    new Person(1122, "Sasho"),
                    new Person(2233, "Alex"),
                    new Person(3344, "Mimi"),
                    new Person(4455, "Iva"),
                    new Person(5566, "Rosi"),
                    new Person(7788, "Hristo"),
                    new Person(7788, "Joro"),
                    new Person(6677, "Tanya"));
            }, "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void Test_If_Add_Thows_Exception_When_Add_More_Than_16()
        {
            data = new Database(

                new Person(1111, "Dido"),
                new Person(2222, "Ivo"),
                new Person(3333, "Pesho"),
                new Person(4444, "Dimitrichko"),
                new Person(5555, "Viktor"),
                new Person(6666, "Nqkoi"),
                new Person(7777, "Drug"),
                new Person(8888, "Gosho"),
                new Person(9999, "Tedo"),
                new Person(1122, "Sasho"),
                new Person(2233, "Alex"),
                new Person(3344, "Mimi"),
                new Person(4455, "Iva"),
                new Person(5566, "Rosi"),
                new Person(7788, "Hristo"),
                new Person(6677, "Tanya"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Add(new Person(0000, "Nevyzmojen"));
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void Test_If_Add_Thows_Exception_When_Add_Person_With_Same_Name()
        {
            data = new Database(new Person(1111, "Dido"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Add(new Person(0000, "Dido"));
            }, "There is already user with this username!");
        }

        [Test]
        public void Test_If_Add_Thows_Exception_When_Add_Person_With_Same_Id()
        {
            data = new Database(new Person(1111, "Dido"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Add(new Person(1111, "Nevyzmojen"));
            }, "There is already user with this Id!");
        }

        [Test]
        [TestCaseSource("InitializeAdd")]
        public void Test_If_Add_Elemenst_To_Last_Position(Person[] persons, Person[] personsToAdd, int count)
        {
            data = new Database(persons);

            foreach (var item in personsToAdd)
            {
                data.Add(item);
            }
            Assert.AreEqual(count, data.Count);
        }

        public static IEnumerable<TestCaseData> InitializeAdd()
        {
            yield return new TestCaseData(new Person[]
            {
                new Person(1111, "Dido"),
                new Person(2222, "Ivo")
            },
            new Person[]
            {
                new Person(3333, "Vasko"),
                new Person(4444, "Mitko")
            }, 4);

            yield return new TestCaseData(new Person[]
            {
                new Person(1111, "Dido"),
                new Person(2222, "Ivo"),
                new Person(4444, "Dimitrichko"),
                new Person(5555, "Viktor"),
            }, new Person[]
            {
                new Person(3333, "Vasko"),
                new Person(7777, "Mitko")
            }, 6);
        }

        [Test]
        public void Test_If_Removed_Elemenst_At_Last_Position()
        {
            data = new Database(

                new Person(1111, "Dido"),
                new Person(2222, "Ivo"),
                new Person(3333, "Pesho"));

            data.Remove();
            Assert.AreEqual(2, data.Count);
        }

        [Test]
        public void Test_If_Remove_Method_Removes_From_Empty_Collection()
        {
            data = new Database();
            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Remove();
            });
        }

        [Test]
        public void When_Search_User_By_Name_Missing_From_Collection_Throw_Exception()
        {
            data = new Database(

                new Person(1111, "Dido"),
                new Person(2222, "Ivo"),
                new Person(3333, "Pesho"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                data.FindByUsername("Go6o");
            }, "No user is present by this username!");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void When_Search_User_By_Null_Name_Throw_Exception(string name)
        {
            data = new Database(

                new Person(1111, "Dido"),
                new Person(2222, "Ivo"),
                new Person(3333, "Pesho"));

            Assert.Throws<ArgumentNullException>(() =>
            {
                data.FindByUsername(name);
            });
        }

        [Test]
        public void When_Search_User_Should_Return_Person()
        {
            data = new Database(

                new Person(1111, "Dido"),
                new Person(2222, "Ivo"),
                new Person(3333, "Pesho"));

            Assert.IsAssignableFrom<Person>(data.FindByUsername("Ivo"));
        }

        [Test]
        public void When_Search_User_By_Id_Missing_From_Collection_Throw_Exception()
        {
            data = new Database(

                new Person(1111, "Dido"),
                new Person(2222, "Ivo"),
                new Person(3333, "Pesho"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                data.FindById(6666);
            }, "No user is present by this ID!");
        }

        [Test]
        public void When_Search_User_By_Negativ_Id_Throw_Exception()
        {
            data = new Database(

                new Person(1111, "Dido"),
                new Person(2222, "Ivo"),
                new Person(3333, "Pesho"));

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                data.FindById(-1);
            }, "Id should be a positive number!");
        }

        [Test]
        public void When_Search_User_Id_Should_Return_Person()
        {
            data = new Database(

                new Person(1111, "Dido"),
                new Person(2222, "Ivo"),
                new Person(3333, "Pesho"));

            Assert.IsAssignableFrom<Person>(data.FindById(1111));
        }
    }
}