using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab7
{
    class Program
    {
        private static bool isWorking = true;
        private static Library library;
        static void Main(string[] args)
        {
            library = new Library();

            Console.WriteLine("Добро пожаловать в библиотеку!\n");
            while(isWorking)
            {
                HandleCommand(Read("> "));
            }
        }

        static string Read(string msg)
        {
            Console.Write(msg);
            return Console.ReadLine();
        }

        static DateTime ReadDate(string msg)
        {
            DateTime result = DateTime.Now;
            while (true)
            {
                string[] date = Read(msg).Split('.');
                if (date.Length == 3)
                {
                    int year, month, day;
                    if (int.TryParse(date[0], out day) &&
                        int.TryParse(date[1], out month) &&
                        int.TryParse(date[2], out year))
                    {
                        try
                        {
                            result = new DateTime(year, month, day);
                            break;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Ошибка: несуществующая дата.");
                            continue;
                        }
                    }
                }
                Console.WriteLine("Ошибка: неверный формат. Введите \"дд.мм.гггг\"");
            }
            return result;
        }

        static void HandleCommand(string command)
        {
            switch(command)
            {
                case "add":
                    CommandAddBook();
                    break;
                case "info":
                    CommandInfo();
                    break;
                case "search":
                    CommandSearch();
                    break;
                case "help":
                    break;
                case "exit":
                    isWorking = false;
                    break;
                default:
                    break;
            }
        }

        static void CommandAddBook()
        {
            string title = Read("Название: "),
                author = Read("Автор: "),
                annotation = Read("Аннотация: "),
                isbn = Read("ISBN: ");
            DateTime pubdate = ReadDate("Дата публикации (дд.мм.гггг): ");

            library.AddBook(new Book(title, author, annotation, isbn, pubdate));
        }

        static void CommandInfo()
        {
            string isbn = Read("ISBN (пусто для всего списка): ");
            if (string.IsNullOrWhiteSpace(isbn))
            {
                ShowBooks(library.Books);
            } else
            {
                Book book = library.FindBookByISBN(isbn);
                if (book == null) Console.WriteLine("Книга с таким ISBN не найдена.");
                else ShowBooks(book);
            }
        }

        static void CommandSearch()
        {
            string[] keywords = Read("Введите ключевые слова: ").Split();
            List<Book> books = library.Search(keywords);
            if (books.Count > 0) ShowBooks(books);
            else Console.WriteLine("По вашему запросу ничего не найдено.");
        }

        static string Substring(string str, int length) => str.Length > length ? str.Substring(0, length - 3) + "..." : str;

        static void ShowBooks(Book book) => ShowBooks(new List<Book>() { book });

        static void ShowBooks(List<Book> books)
        {/*
            foreach (var book in books)
            {
                int[] cols = new int[5] {
                    book.Title.Length,
                    book.AuthorName.Length,
                    book.Annotation.Length,
                    book.ISBN.Length,
                    book.PublicationDate.ToShortDateString().Length
                };
                for (int i = 0; i < colLength.Length; i++) colLength[i] = colLength[i] < cols[i] ? cols[i] : colLength[i];
            }
            */
            Console.WriteLine(new String('-', 104));
            Console.WriteLine("| {0,16} | {1,16} | {2,25} | {3,16} | {4,15} |", "Название", "Автор", "Аннотация", "ISBN", "Дата публикации");
            Console.WriteLine(new String('-', 104));
            foreach (var book in books)
            {
                Console.WriteLine("| {0,16} | {1,16} | {2,25} | {3,16} | {4,15} |",
                    book.Title,
                    book.AuthorName,
                    Substring(book.Annotation, 25),
                    book.ISBN,
                    book.PublicationDate.ToShortDateString()
                    );
            }
            Console.WriteLine(new String('-', 104));
        }
    }
}
