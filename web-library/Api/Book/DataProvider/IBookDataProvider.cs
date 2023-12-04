using web_library.Api.Book.Model;

namespace web_library.Api.Book.DataProvider;

public interface IBookDataProvider
{
    ICollection<BookModel> getAll();
    BookModel getById(int id);
}