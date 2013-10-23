using Demo.BookStore.Contexts;
using Demo.BookStore.Contexts.Fakes;
using Demo.BookStore.Models;
using Demo.BookStore.Repositories;
using Fakes.Contrib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.BookStore.Tests.Repositories
{
    [TestClass]
    public class BookRepositoryTest
    {
        [TestMethod]
        public void InsertShouldInsertTheBookInTheContext()
        {
            // Arrange
            var book = MakeBook();
            var context = new StubIBookContext().WithObserver();
            var sut = MakeSut(context);

            // Act
            sut.Insert(book);

            // Assert
            context.AssertWasCalled(mock => mock.InsertBook(book));
        }

        [TestMethod]
        public void InsertShouldInsertAnyBookInTheContext()
        {
            // Arrange
            var book = MakeBook();
            var context = new StubIBookContext().WithObserver();
            var sut = MakeSut(context);

            // Act
            sut.Insert(book);

            // Assert
            context.AssertWasCalled(mock => mock.InsertBook(With.Any<Book>()));
        }

        [TestMethod]
        public void InsertShouldInsertABookWithMatchingTitleInTheContext()
        {
            // Arrange
            const string title = "The Lord of the Rings";
            var context = new StubIBookContext().WithObserver();
            var sut = MakeSut(context);

            // Act
            sut.Insert(MakeBook(title));

            // Assert
            context.AssertWasCalled(mock => mock.InsertBook(With<Book>.Like(book => book.Title == title)));
        }

        private static Book MakeBook(string title = "Some title")
        {
            var book = new Book
            {
                Title = title
            };

            return book;
        }

        private static IBookRepository MakeSut(IBookContext bookContext = null)
        {
            bookContext = bookContext ?? new StubIBookContext();

            var sut = new BookRepository(bookContext);

            return sut;
        }
    }
}
