using web_library.Book.Request;

namespace web_library.Book.Service
{
    public interface IBookService
    {
        void createBook(CreateBookRequest request);
    }
}