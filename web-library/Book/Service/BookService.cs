using web_library.Book.DataProvider;
using web_library.Book.Request;
namespace web_library.Book.Service
{
    using Entity;
    using Newtonsoft.Json;
    using web_library.Book.Repository;

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookCopyRepository _bookCopyRepository;
        public BookService(IBookRepository bookRepository, IBookCopyRepository bookCopyRepository)
        {
            _bookRepository = bookRepository;
            _bookCopyRepository = bookCopyRepository;
        }

        public void createBook(CreateBookRequest request)
        {
            var jsonString = JsonConvert.SerializeObject(request);

            Book? entity = JsonConvert.DeserializeObject<Book>(jsonString) ?? throw new JsonException();

            _bookRepository.Add(entity);

            for (int i = 0; i < request.numberOfCopies; i++)
            {
                BookCopy copy = new(entity);
                _bookCopyRepository.Add(copy);
            }

            _bookRepository.Update(entity);

            return;
        }
    }
}
