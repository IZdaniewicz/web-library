using web_library.Api.Book.Request;

namespace web_library.Api.Book.Service;

public interface IBookService
{
    void createBook(CreateBookRequest request);
}