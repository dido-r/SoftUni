namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void Test_Ctor()
        {
            var book1 = new Book("Necronomicon", "Lovecraft");
            Assert.AreEqual("Necronomicon", book1.BookName);
            Assert.AreEqual("Lovecraft", book1.Author);
            var book2 = new Book("Four Past Midnight", "Stephen King");
            Assert.AreEqual("Four Past Midnight", book2.BookName);
            Assert.AreEqual("Stephen King", book2.Author);
            Assert.Throws<ArgumentException>(() =>
            {
                var book3 = new Book(null, "Stephen King");
            });
            Assert.Throws<ArgumentException>(() =>
            {
                var book3 = new Book(string.Empty, "Stephen King");
            });
            Assert.Throws<ArgumentException>(() =>
            {
                var book3 = new Book("Necronomicon", null);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                var book3 = new Book("Necronomicon", string.Empty);
            });
            Assert.AreEqual(0, book1.FootnoteCount);
        }

        [Test]
        public void Test_AddFootnote()
        {
            var book1 = new Book("Necronomicon", "Lovecraft");
            book1.AddFootnote(123, "nice");
            Assert.AreEqual(1, book1.FootnoteCount);
            Assert.Throws<InvalidOperationException>(() =>
            {
                book1.AddFootnote(123, "very nice");
            });
        }

        [Test]
        public void Test_FindFootnote()
        {
            var book1 = new Book("Necronomicon", "Lovecraft");
            book1.AddFootnote(123, "nice");
            Assert.AreEqual(1, book1.FootnoteCount);
            Assert.Throws<InvalidOperationException>(() =>
            {
                book1.FindFootnote(1234);
            });

            Assert.AreEqual("Footnote #123: nice", book1.FindFootnote(123));
            Assert.IsInstanceOf<string>(book1.FindFootnote(123));
        }

        [Test]
        public void Test_AlterFootnote()
        {
            var book1 = new Book("Necronomicon", "Lovecraft");
            book1.AddFootnote(123, "nice");
            Assert.AreEqual(1, book1.FootnoteCount);
            Assert.Throws<InvalidOperationException>(() =>
            {
                book1.AlterFootnote(1234, "very nice");
            });

            book1.AlterFootnote(123, "Very nice");
            Assert.AreEqual("Footnote #123: Very nice", book1.FindFootnote(123));
        }
    }
}