using System;
using System.Collections.Generic;
using web_library.Book.Entity;

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
            throw new NotImplementedException();
        }

        public void Remove(BookCopy entity)
        {
            throw new NotImplementedException();
        }
    }
}
