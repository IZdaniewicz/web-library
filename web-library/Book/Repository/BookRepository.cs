using web_library.Book.DataProvider;

namespace web_library.Book.Repository;
using SharedExceptions;
using Entity;

public class BookRepository : IBookRepository
{
    private readonly DataContext _context;
    public BookRepository(DataContext context)
    {
        _context = context;
    }

    public void Add(Book entity)
    {
        _context.Books.Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<Book> GetAll()
    {
        throw new NotImplementedException();
    }

    public Book GetByIdOrThrow(int id)
    {
        Book? book = _context.Books.Find(id) ?? throw new NotFoundException("Book "+id+" not found in reposiotry");
        return book;
    }

    public void Remove(Book entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Book entity)
    {
        _context.Books.Update(entity);
        _context.SaveChanges();
    }
}
