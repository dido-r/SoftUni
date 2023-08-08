using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
            this.books.Sort(new BookComparator());
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int index = -1;
            public Book Current => books[index];

            public LibraryIterator(List<Book> books)
            {
                this.books = new List<Book>(books);
            }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                return ++index < books.Count;
            }
            public void Dispose() { }

            public void Reset() { }
        }
    }
}
