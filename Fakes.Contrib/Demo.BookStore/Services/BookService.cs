using System.Collections.Generic;
using Demo.BookStore.Models;
using Demo.BookStore.Repositories;
using Demo.BookStore.Services.Dtos;
using System;
using System.Linq;

namespace Demo.BookStore.Services
{
    public class BookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;
        }

        public void InsertBook(BookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title
            };

            _repository.Insert(book);
        }

        public void InsertAllBooks(BookDto[] dtos)
        {
            var books = dtos.Select(dto => new Book
            {
                Title = dto.Title
            }).ToArray();

            _repository.InsertAll(books);
        }

        public void UpdateAllBooks(IEnumerable<BookDto> dtos)
        {
            var books = dtos.Select(dto => new Book
            {
                Title = dto.Title
            });

            _repository.UpdateAll(books);
        }
    }
}
