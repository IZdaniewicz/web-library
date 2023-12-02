namespace web_library.Api.Book.Repository
{
    using Entity;
    using web_library.Api.Book.Entity;

    public interface IBookRepository : IGenericRepository<Book>
    {
        public void Update(Book book);
    }
}