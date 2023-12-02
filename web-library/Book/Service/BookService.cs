using web_library.Book.DataProvider;
using web_library.Book.Request;
namespace web_library.Book.Service
{
    using Entity;
    using Genre.Entity;
    using Newtonsoft.Json;
    using web_library.Book.Repository;
    using web_library.Genre.Repository;

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookCopyRepository _bookCopyRepository;
        private readonly IGenreRepository _genreRepository;

        public BookService(IBookRepository bookRepository, IBookCopyRepository bookCopyRepository, IGenreRepository genreRepository)
        {
            _bookRepository = bookRepository;
            _bookCopyRepository = bookCopyRepository;
            _genreRepository = genreRepository;
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
        public void assigneGenre(AssigneGenreToBookRequest request)
        {
            Book? book = _bookRepository.GetByIdOrThrow(request.book_id);
            foreach (var id in request.genres_ids)
            {
                Genre? genre = _genreRepository.GetByIdOrThrow(id);
                book.AddGenre(genre);
            }
            _bookRepository.Update(book);
        }
    }
}
