using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Zadanie1
{
    public class ConstDataFiller : DataFiller
    {
        public override void Fill(ref DataContext context)
        {
            var bookReader = context.bookReader;
            var books = context.books;
            var events = context.events;
            var bookStates = context.bookStates;

            // create book reader objects
            BookReader reader1 = new BookReader()
            {
                Age = 20,
                FirstName = "Herbysław",
                LastName = "Przytoka",
                Telephone = "553245634"
            };
            BookReader reader2 = new BookReader()
            {
                Age = 25,
                FirstName = "Mirella",
                LastName = "Gogol",
                Telephone = "63463785"
            };
            BookReader reader3 = new BookReader()
            {
                Age = 51,
                FirstName = "Salomea",
                LastName = "Tatarkiewicz",
                Telephone = "465432654"
            };

            // initialize book reader list
            bookReader.Add(reader1);
            bookReader.Add(reader2);
            bookReader.Add(reader3);

            // create book objects
            Book book1 = new Book()
            {
                Isbn = "176738871606",
                Title = "Corpus Aristotelicum",
                Author = "Arystoteles",
                ReleaseYear = 2016
            };
            Book book2 = new Book()
            {
                Isbn = "8456737750210",
                Title = "Historia animalium",
                Author = "Arystoteles",
                ReleaseYear = 2015
            };
            Book book3 = new Book()
            {
                Isbn = "378836548722",
                Title = "Metafizyka",
                Author = "Arystoteles",
                ReleaseYear = 2016
            };
            Book book4 = new Book()
            {
                Isbn = "5678580751026",
                Title = "The Journal of Julius Rodman",
                Author = "Edgar Allan Poe",
                ReleaseYear = 2016
            };
            Book book5 = new Book()
            {
                Isbn = "9788327154590",
                Title = "The Philosophy of Furniture",
                Author = "Edgar Allan Poe",
                ReleaseYear = 2016
            };
            Book book6 = new Book()
            {
                Isbn = "9788327155825",
                Title = "Świat jako wola i przedstawienie",
                Author = "Arthur Schopenhauer",
                ReleaseYear = 1994
            };
            Book book7 = new Book()
            {
                Isbn = "9788327155917",
                Title = "Czworaki korzeń zasady racji dostatecznej",
                Author = "Arthur Schopenhauer",
                ReleaseYear = 2003
            };

            Book book8 = new Book()
            {
                Isbn = "9788327185917",
                Title = "Góry",
                Author = "Daniel Urubko",
                ReleaseYear = 2019
            };

            // initialize book dictionary
            context.books.Add(book1.Isbn, book1);
            context.books.Add(book2.Isbn, book2);
            context.books.Add(book3.Isbn, book3);
            context.books.Add(book4.Isbn, book4);
            context.books.Add(book5.Isbn, book5);
            context.books.Add(book6.Isbn, book6);
            context.books.Add(book7.Isbn, book7);
            context.books.Add(book8.Isbn, book8);

            // create bookStates

            BookState bookState1 = new BookState
            {
                DateOfPurchase = new DateTimeOffset(2017, 5, 21, 00, 00, 00, new TimeSpan(1, 0, 0)),
                Book = book1,
                Available = false
            };

            BookState bookState2 = new BookState
            {
                DateOfPurchase = new DateTimeOffset(2017, 5, 21, 00, 00, 00, new TimeSpan(1, 0, 0)),
                Book = book2,
                Available = false
            };

            BookState bookState3 = new BookState
            {
                DateOfPurchase = new DateTimeOffset(2017, 5, 21, 00, 00, 00, new TimeSpan(1, 0, 0)),
                Book = book3,
                Available = true
            };

            BookState bookState4 = new BookState
            {
                DateOfPurchase = new DateTimeOffset(2017, 5, 21, 00, 00, 00, new TimeSpan(1, 0, 0)),
                Book = book4,
                Available = true
            };

            BookState bookState5 = new BookState
            {
                DateOfPurchase = new DateTimeOffset(2017, 5, 21, 00, 00, 00, new TimeSpan(1, 0, 0)),
                Book = book5,
                Available = true
            };

            BookState bookState6 = new BookState
            {
                DateOfPurchase = new DateTimeOffset(2017, 5, 21, 00, 00, 00, new TimeSpan(1, 0, 0)),
                Book = book6,
                Available = true
            };

            BookState bookState7 = new BookState
            {
                DateOfPurchase = new DateTimeOffset(2017, 5, 21, 00, 00, 00, new TimeSpan(1, 0, 0)),
                Book = book7,
                Available = true
            };

            BookState bookState8 = new BookState
            {
                DateOfPurchase = new DateTimeOffset(2018, 12, 13, 00, 00, 00, new TimeSpan(1, 0, 0)),
                Book = book7,
                Available = true
            };

            // initialize bookStates List
            bookStates.Add(bookState1);
            bookStates.Add(bookState2);
            bookStates.Add(bookState3);
            bookStates.Add(bookState4);
            bookStates.Add(bookState5);
            bookStates.Add(bookState6);
            bookStates.Add(bookState7);
            bookStates.Add(bookState8);

            //create events
            Event event1 = new Event()
            {
                BookState = bookState1,
                BookReader = reader1,
                BorrowDate = new DateTimeOffset(2018, 04, 20, 12, 00, 00, new TimeSpan(1, 0, 0)),
                ReturnDate = new DateTimeOffset(2018, 07, 01, 12, 00, 00, new TimeSpan(1, 0, 0)),
            };

            Event event2 = new Event()
            {
                BookState = bookState2,
                BookReader = reader2,
                BorrowDate = new DateTimeOffset(2018, 10, 11, 12, 00, 00, new TimeSpan(1, 0, 0)),
            };

            Event event3 = new Event()
            {
                BookState = bookState1,
                BookReader = reader1,
                BorrowDate = new DateTimeOffset(2018, 12, 20, 12, 00, 00, new TimeSpan(1, 0, 0)),
                ReturnDate = new DateTimeOffset(2019, 01, 01, 12, 00, 00, new TimeSpan(1, 0, 0)),
            };

            Event event4 = new Event()
            {
                BookState = bookState1,
                BookReader = reader1,
                BorrowDate = DateTimeOffset.Now
            };

            // initialize events collection
            events.Add(event1);
            events.Add(event2);
            events.Add(event3);
            events.Add(event4);
        }
    }
}
