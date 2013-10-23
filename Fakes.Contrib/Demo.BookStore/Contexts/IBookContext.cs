using Demo.BookStore.Models;

namespace Demo.BookStore.Contexts
{
    public interface IBookContext
    {
        void InsertBook(Book book);
        void InsertBooks(Book[] books);
        void UpdateBook(Book book);
    }
}