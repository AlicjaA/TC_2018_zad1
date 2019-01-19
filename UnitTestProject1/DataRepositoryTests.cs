using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using Zadanie1;
using System.Linq;

namespace UnitTestTPzad1
{
    [TestClass()]
    public class DataRepositoryTests
    {
        private DataRepository repository;
        private DataContext context;
        private ConstDataFiller dataFiller;

        [TestInitialize]
        public void TestInitialize()
        {
            dataFiller = new ConstDataFiller();
            context = new DataContext();
            repository = new DataRepository(dataFiller)
            {
                Data = context
            };
            repository.Fill();
        }

        [TestMethod()]
        public void DataRepositoryTest()
        {

        }

        // test for Book class
        [TestMethod()]
        public void AddBookTest()
        {
            int beforeSize = context.books.Count;
            var beforeLastBook = context.books.Last();
            var bookToAdd = new Book()
            {
                Isbn = "76548152305",
                Title = "Uczta",
                Author = "Platon",
                ReleaseYear = 2012
            };
            repository.AddBook(bookToAdd);
            int afterSize = context.books.Count;
            var afterLastBook = context.books.Last();

            // check sizes
            Assert.AreNotEqual(beforeSize, afterSize);

            // check if last books aren't equal
            Assert.AreNotEqual(beforeLastBook, afterLastBook);

            // check if the book is in the list
            Assert.IsTrue(context.books.ContainsKey(bookToAdd.Isbn));
        }

        [TestMethod()]
        public void GetBookTest()
        {
            var listOfKeys = context.books.Keys;
            foreach (string key in listOfKeys)
            {
                var expectedBook = context.books[key];
                Assert.AreEqual(expectedBook, repository.GetBook(key));
            }
        }

        [TestMethod()]
        public void GetAllBooksTest()
        {
            var expectedBooks = context.books.Values;
            var actualBooks = repository.GetAllBooks();
            foreach (Book book in actualBooks)
            {
                Assert.IsTrue(expectedBooks.Contains(book));
            }
        }

        [TestMethod()]
        public void UpdateBookTest()
        {
            var oldBook = repository.GetBook("378836548722");
            var newBook = new Book()
            {
                Isbn = "378836548723",
                Title = "Nieuniknione",
                Author = "Kevin Kelly",
                ReleaseYear = 2014
            };
            int beforeSize = context.books.Count;
            repository.UpdateBook(oldBook, newBook);
            int afterSize = context.books.Count;

            var bookAfterUpdate = context.books[newBook.Isbn];

            // compare sizes
            Assert.AreEqual(beforeSize, afterSize);

            // compare references (should be different because we only modify properties)
            Assert.IsFalse(object.ReferenceEquals(bookAfterUpdate, newBook));

            // compare book's properties
            Assert.AreEqual(newBook.Isbn, bookAfterUpdate.Isbn);
            Assert.AreEqual(newBook.Author, bookAfterUpdate.Author);
            Assert.AreEqual(newBook.ReleaseYear, bookAfterUpdate.ReleaseYear);
            Assert.AreEqual(newBook.Title, bookAfterUpdate.Title);
        }

        [TestMethod()]
        public void DeleteBookTest()
        {
            var book = repository.GetBook("5678580751026");
            Assert.IsTrue(context.books.ContainsKey("5678580751026"));
            repository.DeleteBook(book);
            Assert.IsFalse(context.books.ContainsKey("5678580751026"));
            Assert.IsFalse(context.books.ContainsValue(book));
        }

        // test for BookReader class
        [TestMethod()]
        public void AddBookReaderTest()
        {
            int beforeSize = context.bookReader.Count;
            var beforeLastBookReader = context.bookReader.Last();
            var bookReaderToAdd = new BookReader()
            {
                Age = 18,
                FirstName = "Oskar",
                LastName = "Neuman",
                Telephone = "665456789"
            };
            repository.AddBookReader(bookReaderToAdd);
            int afterSize = context.bookReader.Count;
            var afterLastBookReader = context.bookReader.Last();

            // check sizes
            Assert.AreNotEqual(beforeSize, afterSize);

            // check if last books aren't equal
            Assert.AreNotEqual(beforeLastBookReader, afterLastBookReader);

            // check if the book is in the list
            Assert.IsTrue(context.bookReader.Contains(bookReaderToAdd));
        }

        [TestMethod()]
        public void GetBookReaderTest()
        {
            int bookReaderIndex = new Random().Next(0, context.bookReader.Count);
            var expectedBookReader = context.bookReader[bookReaderIndex];
            Assert.AreEqual(expectedBookReader, repository.GetBookReader(bookReaderIndex));
        }

        [TestMethod()]
        public void GetAllBookReadersTest()
        {
            var expectedBookReaders = context.bookReader;
            Assert.AreEqual(expectedBookReaders, repository.GetAllBookReaders());
        }

        [TestMethod()]
        public void UpdateBookReaderTest()
        {
            int bookReaderIndex = context.bookReader.Count - 1;
            var oldBookReader = repository.GetBookReader(bookReaderIndex);
            var newBookReader = new BookReader()
            {
                Age = 34,
                FirstName = "Roma",
                LastName = "Świerk",
                Telephone = "123456789"
            };
            int beforeSize = context.bookReader.Count;
            repository.UpdateBookReader(oldBookReader, newBookReader);
            int afterSize = context.bookReader.Count;

            var bookReaderAfterUpdate = repository.GetBookReader(bookReaderIndex);

            // compare sizes
            Assert.AreEqual(beforeSize, afterSize);

            // compare references (should be different because we only change properties)
            Assert.IsFalse(object.ReferenceEquals(bookReaderAfterUpdate, newBookReader));

            // compare properties
            Assert.AreEqual(newBookReader.Age, bookReaderAfterUpdate.Age);
            Assert.AreEqual(newBookReader.FirstName, bookReaderAfterUpdate.FirstName);
            Assert.AreEqual(newBookReader.LastName, bookReaderAfterUpdate.LastName);
            Assert.AreEqual(newBookReader.Telephone, bookReaderAfterUpdate.Telephone);
        }

        [TestMethod()]
        public void DeleteBookReaderTest()
        {
            int bookReaderIndex = new Random().Next(0, context.bookReader.Count);
            var bookReader = context.bookReader[bookReaderIndex];
            Assert.IsTrue(context.bookReader.Contains(bookReader));
            repository.DeleteBookReader(bookReader);
            Assert.IsFalse(context.bookReader.Contains(bookReader));
        }

        // tests for BookState class
        [TestMethod()]
        public void AddBookStateTest()
        {
            int beforeSize = context.bookStates.Count;
            var beforeLastBookState = context.bookStates.Last();
            var bookStateToAdd = new BookState()
            {
                DateOfPurchase = new DateTimeOffset(year: 2016, month: 4, day: 12, hour: 00, minute: 00, second: 00, offset: new TimeSpan(1, 0, 0)),
                Book = new Book()
                {
                    Isbn = "978832745203",
                    Title = "Historia myśli ekonomicznej",
                    Author = "Adam Smith",
                    ReleaseYear = 2014
                }
            };
            repository.AddBookState(bookStateToAdd);
            int afterSize = context.bookStates.Count;
            var afterLastBookState = context.bookStates.Last();

            // check sizes
            Assert.AreNotEqual(beforeSize, afterSize);

            // check if last books aren't equal
            Assert.AreNotEqual(beforeLastBookState, afterLastBookState);

            // check if the book is in the list
            Assert.IsTrue(context.bookStates.Contains(bookStateToAdd));
        }

        [TestMethod()]
        public void GetBookStateTest()
        {
            int bookStateIndex = new Random().Next(0, context.bookStates.Count);
            var expectedBookState = context.bookStates[bookStateIndex];
            Assert.AreEqual(expectedBookState, repository.GetBookState(bookStateIndex));
        }

        [TestMethod()]
        public void GetAllBookStatesTest()
        {
            var expectedBookStates = context.bookStates;
            Assert.AreEqual(expectedBookStates, repository.GetAllBookStates());
        }

        [TestMethod()]
        public void UpdateBookStateTest()
        {
            int bookStateIndex = context.bookStates.Count - 1;
            var oldBookState = repository.GetBookState(bookStateIndex);
            var newBookState = new BookState()
            {
                DateOfPurchase = new DateTimeOffset(year: 2000, month: 10, day: 11, hour: 01, minute: 30, second: 12, offset: new TimeSpan(1, 0, 0)),
                Book = new Book()
                {
                    Isbn = "Gramatyka",
                    Title = "Sokrates",
                    Author = "Test",
                    ReleaseYear = 2015
                }
            };
            int beforeSize = context.bookStates.Count;
            repository.UpdateBookState(oldBookState, newBookState);
            int afterSize = context.bookStates.Count;

            var bookStateAfterUpdate = repository.GetBookState(bookStateIndex);

            // compare sizes
            Assert.AreEqual(beforeSize, afterSize);

            // compare references (should be different)
            Assert.IsFalse(object.ReferenceEquals(bookStateAfterUpdate, newBookState));

            // compare properties
            Assert.AreEqual(newBookState.Available, bookStateAfterUpdate.Available);
            Assert.AreEqual(newBookState.Book, bookStateAfterUpdate.Book);
            Assert.AreEqual(newBookState.DateOfPurchase, bookStateAfterUpdate.DateOfPurchase);
        }

        [TestMethod()]
        public void DeleteBookStateTest()
        {
            int bookStateIndex = new Random().Next(0, context.bookStates.Count);
            var bookState = context.bookStates[bookStateIndex];
            Assert.IsTrue(context.bookStates.Contains(bookState));
            repository.DeleteBookState(bookState);
            Assert.IsFalse(context.bookStates.Contains(bookState));
        }

        // tests for Event class
        [TestMethod()]
        public void AddEventTest()
        {
            int beforeSize = context.events.Count;
            var beforeLastEvent = context.events.Last();
            var eventToAdd = new Event()
            {
                BookState = new BookState()
                {
                    DateOfPurchase = new DateTimeOffset(year: 2019, month: 1, day: 02, hour: 14, minute: 18, second: 00, offset: new TimeSpan(1, 0, 0)),
                    Book = new Book()
                    {
                        Isbn = "88888",
                        Title = "Elementarne pojęcia socjologii",
                        Author = "Jan Szczepański",
                        ReleaseYear = 1964
                    }
                },
                BookReader = new BookReader()
                {
                    Age = 02,
                    FirstName = "Bachorek",
                    LastName = "Słodziutki",
                    Telephone = "mamusi"
                },
                BorrowDate = new DateTimeOffset(year: 2018, month: 11, day: 30, hour: 11, minute: 30, second: 00, offset: new TimeSpan(1, 0, 0)),
                ReturnDate = new DateTimeOffset(year: 2019, month: 03, day: 15, hour: 11, minute: 30, second: 00, offset: new TimeSpan(1, 0, 0)),

            };
            repository.AddEvent(eventToAdd);
            int afterSize = context.events.Count;
            var afterLastEvent = context.events.Last();

            // check sizes
            Assert.AreNotEqual(beforeSize, afterSize);

            // check if last books aren't equal
            Assert.AreNotEqual(beforeLastEvent, afterLastEvent);

            // check if the book is in the list
            Assert.IsTrue(context.events.Contains(eventToAdd));
        }

        [TestMethod()]
        public void GetEventTest()
        {
            int eventIndex = new Random().Next(0, context.events.Count);
            var expectedEvent = context.events[eventIndex];
            Assert.AreEqual(expectedEvent, repository.GetEvent(eventIndex));

        }

        [TestMethod()]
        public void GetAllEventsTest()
        {
            var expectedEvents = context.events;
            Assert.AreEqual(expectedEvents, repository.GetAllEvents());
        }

        [TestMethod()]
        public void UpdateEventTest()
        {
            int eventIndex = context.events.Count - 1;
            var oldEvent = repository.GetEvent(eventIndex);
            var newEvent = new Event()
            {
                BookState = new BookState()
                {
                    DateOfPurchase = new DateTimeOffset(year: 1998, month: 3, day: 18, hour: 14, minute: 12, second: 00, offset: new TimeSpan(1, 0, 0)),
                    Book = new Book()
                    {
                        Isbn = "8765456789",
                        Title = "Wojna i pokój",
                        Author = "Lew Tołstoj",
                        ReleaseYear = 1889
                    }
                },
                BookReader = new BookReader()
                {
                    Age = 1800,
                    FirstName = "Juliusz",
                    LastName = "Cezar",
                    Telephone = "nie_ma"
                },
                BorrowDate = new DateTimeOffset(year: 2018, month: 04, day: 12, hour: 12, minute: 30, second: 00, offset: new TimeSpan(1, 0, 0)),
                ReturnDate = new DateTimeOffset(year: 2018, month: 10, day: 13, hour: 12, minute: 30, second: 00, offset: new TimeSpan(1, 0, 0)),

            };
            int beforeSize = context.events.Count;
            repository.UpdateEvents(oldEvent, newEvent);
            int afterSize = context.events.Count;

            var eventAfterUpdate = repository.GetEvent(eventIndex);

            // compare sizes
            Assert.AreEqual(beforeSize, afterSize);

            // compare references
            Assert.IsFalse(object.ReferenceEquals(eventAfterUpdate, newEvent));

            // compare properties
            Assert.AreEqual(newEvent.BookReader, eventAfterUpdate.BookReader);
            Assert.AreEqual(newEvent.BookState, eventAfterUpdate.BookState);
            Assert.AreEqual(newEvent.BorrowDate, eventAfterUpdate.BorrowDate);
            Assert.AreEqual(newEvent.ReturnDate, eventAfterUpdate.ReturnDate);
        }

        [TestMethod()]
        public void DeleteEventTest()
        {
            int eventIndex = new Random().Next(0, context.events.Count);
            var event1 = context.events[eventIndex];
            Assert.IsTrue(context.events.Contains(event1));
            repository.DeleteEvent(event1);
            Assert.IsFalse(context.events.Contains(event1));
        }

    }
}
