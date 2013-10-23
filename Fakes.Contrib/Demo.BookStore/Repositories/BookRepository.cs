using Demo.BookStore.Contexts;
using Demo.BookStore.Models;
using System;

namespace Demo.BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IBookContext _context;

        public BookRepository(IBookContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public void Insert(Book entity)
        {
            _context.InsertBook(entity);
        }

        public void InsertAll(Book[] books)
        {
            _context.InsertBooks(books);
        }

        public void Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
