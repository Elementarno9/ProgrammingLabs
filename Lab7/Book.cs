using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    class Book
    {
        public readonly string Title;
        public readonly string AuthorName;
        public readonly string Annotation;
        public readonly string ISBN;
        public readonly DateTime PublicationDate;

        public Book(string title, string authorName, string annotation, string isbn, DateTime publicationDate)
        {
            Title = title;
            AuthorName = authorName;
            Annotation = annotation;
            ISBN = isbn;
            PublicationDate = publicationDate;
        }

        public Book(string title)
            : this(title, "", "", "", DateTime.Now)
        {

        }
    }
}
