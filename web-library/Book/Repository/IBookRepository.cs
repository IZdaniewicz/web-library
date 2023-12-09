namespace web_library.Book.Repository;

using Entity;
public interface IBookRepository : IGenericRepository<Book>
{
    public void Update(Book book);
}