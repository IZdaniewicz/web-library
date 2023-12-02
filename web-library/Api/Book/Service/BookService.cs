namespace web_library.Api.Book.Service
{
    using Entity;
    using Newtonsoft.Json;
    using web_library.Api.Book.Entity;
    using web_library.Api.Book.Repository;
    using web_library.Api.Book.Request;

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
