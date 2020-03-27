using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    class Library
    {
        public List<Book> Books { get; private set; }

        public Library(List<Book> books)
        {
            Books = books;
        }

        public Library()
            : this(new List<Book>()) { }

        public void AddBook(Book book) => Books.Add(book);

        public Book? FindBookByISBN(string isbn)
        {
            foreach (var book in Books)
            {
                if (book.ISBN == isbn) return book;
            }
            return null;
        }

        public List<Book> Search(string[] keywords)
        {
            var books = new List<Book>();

            foreach (var book in Books)
            {
                bool contains = false;
                string[] data = new string[] { book.Title, book.AuthorName, book.Annotation, book.ISBN, book.PublicationDate.ToShortDateString() };
                foreach (var str in data)
                {
                    foreach (var keyword in keywords)
                    {
                        if (str.Contains(keyword))
                        {
                            books.Add(book);
                            contains = true;
                            break;
                        }
                    }
                    if (contains) continue;
                }
            }

            return books;
        }
    }
}
