using System;
using System.Collections.Generic;
using web_library.Book.Entity;
using web_library.SharedExceptions;

namespace web_library.Book.Repository
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

        public IEnumerable<BookCopy> FindAll()
        {
            throw new NotImplementedException();
        }

        public BookCopy FindByIdOrThrow(int id)
        {
            return _context.BooksCopy.Find(id) ?? throw new NotFoundException("Book copy" + id + " not found in repository");
        }

        public void Remove(BookCopy entity)
        {
            throw new NotImplementedException();
        }
    }
}
