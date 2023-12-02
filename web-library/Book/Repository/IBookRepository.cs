namespace web_library.Book.DataProvider
{
    using Entity;
    public interface IBookRepository : IGenericRepository<Book>
    {
        public void Update(Book book);
    }
}