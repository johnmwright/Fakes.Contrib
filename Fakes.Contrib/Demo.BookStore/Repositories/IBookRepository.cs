using Demo.BookStore.Models;

namespace Demo.BookStore.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        void InsertAll(Book[] books);
    }
}