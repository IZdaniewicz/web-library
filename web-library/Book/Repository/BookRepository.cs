<<<<<<< HEAD
﻿namespace web_library.Book.Repository;

using Entity;
using Microsoft.EntityFrameworkCore;
using Shared;
using web_library.Book.Entity;

public class BookRepository : IBookRepository
{
    private readonly DataContext _context;
    public BookRepository(DataContext context)
=======
﻿using System;
using System.Collections.Generic;
using web_library.Book.DataProvider;

namespace web_library.Book.Repository
{
    public class BookRepository : IBookRepository
>>>>>>> master
    {
        _context = context;
    }

<<<<<<< HEAD
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
        return _context.Books.Find(id) ?? throw new NotFoundException("Book not found");
    }

    public void Remove(Book entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Book entity)
    {
        _context.Books.Update(entity);
        _context.SaveChanges();
=======
        public void Add(Entity.Book entity)
        {
            _context.Books.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Entity.Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public Entity.Book GetByIdOrThrow(int id)
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
>>>>>>> master
    }
}
