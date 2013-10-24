using Demo.BookStore.Models;
using Demo.BookStore.Repositories;
using Demo.BookStore.Repositories.Fakes;
using Demo.BookStore.Services;
using Demo.BookStore.Services.Dtos;
using Fakes.Contrib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Demo.BookStore.Tests.Services
{
    [TestClass]
    public class BookServiceTest
    {
        [TestMethod]
        public void InsertBookShouldInsertTheBookInTheRepository()
        {
            // Arrange
            var book = MakeBook();
            var repository = new StubIBookRepository().WithObserver();
            var sut = MakeSut(repository);

            // Act
            sut.InsertBook(book);

            // Assert
            repository.AssertWasCalled(mock => mock.Insert(With<Book>.Like(x => x.Title == book.Title)));
        }

        [TestMethod]
        public void InsertAllBooksShouldInsertTheBooksInTheRepository()
        {
            // Arrange
            var books = MakeBooks();
            var repository = new StubIBookRepository().WithObserver();
            var sut = MakeSut(repository);

            // Act
            sut.InsertAllBooks(books);

            // Assert
            repository.AssertWasCalled(mock => mock.InsertAll(With.Enumerable(books).Like<Book>((dto, book) => dto.Title == book.Title).ToArray()));
        }

        private static BookDto[] MakeBooks()
        {
            return new[]
            {
                MakeBook("Random title 1"),
                MakeBook("Random title 3"),
                MakeBook("Random title 2")
            };
        }

        private static BookDto MakeBook(string title = "Random title")
        {
            var book = new BookDto
            {
                Title = title
            };

            return book;
        }

        private static BookService MakeSut(IBookRepository repository = null)
        {
            repository = repository ?? new StubIBookRepository();

            var sut = new BookService(repository);

            return sut;
        }
    }
}
