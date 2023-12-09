<<<<<<< HEAD
﻿namespace web_library.Book.Repository;
using Entity;
using Microsoft.EntityFrameworkCore;
using Shared;
=======
﻿using System;
using System.Collections.Generic;
>>>>>>> master
using web_library.Book.Entity;

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
        return _context.BooksCopy.Find(id) ?? throw new NotFoundException("Book copy (" + id + ") not found repository");
    }

    public void Remove(BookCopy entity)
    {
        throw new NotImplementedException();
    }
}
