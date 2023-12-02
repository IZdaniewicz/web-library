using web_library.Api.Book.Entity;

namespace web_library.Api.Book.Repository
{
    public class BookCopyRepository : IBookCopyRepository
    {
        private readonly DataContext _context;
        public BookCopyRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(BookCopy entity)
        {
            _context.BooksCopy.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<BookCopy> GetAll()
        {
            throw new NotImplementedException();
        }

        public BookCopy GetByIdOrThrow(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(BookCopy entity)
        {
            throw new NotImplementedException();
        }
    }
}
