using System;
using System.Collections.Generic;
using web_library.Book.DataProvider;

namespace web_library.Book.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Entity.Book entity)
        {
            _context.Books.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Entity.Book> FindAll()
        {
            throw new NotImplementedException();
        }

        public Entity.Book FindByIdOrThrow(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Entity.Book entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Entity.Book entity)
        {
            _context.Books.Update(entity);
            _context.SaveChanges();
        }
    }
}
