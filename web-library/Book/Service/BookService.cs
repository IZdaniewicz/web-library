using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using web_library.Book.DataProvider;
using web_library.Book.Entity;
using web_library.Book.Repository;
using web_library.Book.Request;
using web_library.Role.Enum;
using web_library.SharedExceptions;
using web_library.User.Service;

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
        private readonly IUserService _userService;

        public BookService(IBookRepository bookRepository, IBookCopyRepository bookCopyRepository, IGenreRepository genreRepository, IUserService userService)
        {
            _bookRepository = bookRepository;
            _bookCopyRepository = bookCopyRepository;
            _genreRepository = genreRepository;
            _userService = userService;
        }

        [Authorize]
        public void createBook(CreateBookRequest request)
        {
            //if (!_userService.HasRole(_userService.GetUser(), Roles.Librarian))
            //{
            //    throw new UnauthorizedException();
            //}

            var jsonString = JsonConvert.SerializeObject(request);

            Entity.Book? entity = JsonConvert.DeserializeObject<Entity.Book>(jsonString) ?? throw new JsonException();

            _bookRepository.Add(entity);

            for (int i = 0; i < request.NumberOfCopies; i++)
            {
                BookCopy copy = new(entity);
                _bookCopyRepository.Add(copy);
            }

            _bookRepository.Update(entity);
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