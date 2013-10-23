namespace Demo.BookStore.Repositories
{
    public interface IRepository<in T>
    {
        void Insert(T entity);
        void Update(T entity);
    }
}