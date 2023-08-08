namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database data;

        [Test]
        public void Test_Database_Constructor_Is_Data_Length_16()
        {
            data = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Assert.AreEqual(16, data.Count);
        }

        [Test]
        public void Test_If_Add_Elemenst_To_Last_Position()
        {
            data = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9);
            data.Add(10);
            Assert.AreEqual(10, data.Count);
        }

        [Test]
        public void Test_If_Removed_Elemenst_At_Last_Position()
        {
            data = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9);
            data.Remove();
            Assert.AreEqual(8, data.Count);
        }

        [Test]
        public void Test_If_Capacity_Is_Exactly_16_Integers()
        {
            data = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void Test_If_Remove_Method_Removes_From_Empty_Collection()
        {
            data = new Database();
            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Remove();
            }, "The collection is empty!");
        }
        [Test]
        public void Test_If_Fetch_Method_Return_Array_Of_Integers()
        {
            data = new Database(1, 2, 3, 4, 5, 6);
            Assert.IsAssignableFrom<int[]>(data.Fetch());
        }
    }
}
