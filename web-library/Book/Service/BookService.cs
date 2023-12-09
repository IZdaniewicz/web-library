using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using web_library.Role.Enum;
using web_library.SharedExceptions;
using web_library.User.Service;

namespace web_library.Book.Service;
using Entity;
using Repository;
using Request;
using Genre.Entity;
using Genre.Repository;
public class BookService : IBookService
{
    private readonly IGenreRepository _genreRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IBookCopyRepository _bookCopyRepository;
    private readonly IUserService _userService;

    public BookService(IGenreRepository genreRepository, IBookRepository bookRepository, IBookCopyRepository bookCopyRepository, IUserService userService)
    {
        _genreRepository = genreRepository;
        _bookRepository = bookRepository;
        _bookCopyRepository = bookCopyRepository;
        _userService = userService;
    }

    public void createBook(CreateBookRequest request)
    {
        //if (!_userService.HasRole(_userService.GetUser(), Roles.Librarian))
        //{
        //    throw new UnauthorizedException();
        //}

        var jsonString = JsonConvert.SerializeObject(request);

        Book? entity = JsonConvert.DeserializeObject<Book>(jsonString) ?? throw new JsonException();

        _bookRepository.Add(entity);

        for (int i = 0; i < request.numberOfCopies; i++)
        {
            BookCopy copy = new(entity);
            _bookCopyRepository.Add(copy);
        }

        _bookRepository.Update(entity);
    }

    public void assigneGenre(AssigneGenreToBookRequest request)
    {
        Entity.Book? book = _bookRepository.FindByIdOrThrow(request.book_id);
        foreach (var id in request.genres_ids)
        {
            Genre? genre = _genreRepository.FindByIdOrThrow(id);
            book.AddGenre(genre);
        }
        _bookRepository.Update(book);
    }
}