using Microsoft.EntityFrameworkCore;
using web_library.SharedExceptions;

namespace web_library.Book.Repository;
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

    public IEnumerable<Book> FindAll()
    {
        return _context.Books.Include(b => b.Copies).ToList();
    }

    public Book FindByIdOrThrow(int id)
    {
        return _context.Books.Find(id) ?? throw new NotFoundException("Book " + id + " not found in repository");
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
