using web_library.Book.Model;

namespace web_library.Book.DataProvider;

public interface IBookDataProvider
{
    ICollection<BookModel> getAll();
    BookModel getById(int id);
}