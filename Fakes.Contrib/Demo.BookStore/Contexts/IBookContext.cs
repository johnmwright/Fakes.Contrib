using Demo.BookStore.Models;

namespace Demo.BookStore.Contexts
{
    public interface IBookContext
    {
        void InsertBook(Book book);
        void UpdateBook(Book book);
    }
}