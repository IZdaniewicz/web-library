namespace web_library.Book.Repository;

using Entity;
using web_library.Book.Entity;

public interface IBookRepository : IGenericRepository<Book>
{
    public void Update(Book book);
}