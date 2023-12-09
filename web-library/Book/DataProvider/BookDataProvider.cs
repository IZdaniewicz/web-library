﻿namespace web_library.Book.DataProvider;
using Entity;
using web_library.Book.Model;
using web_library.Book.Repository;

public class BookDataProvider : IBookDataProvider
{
    private readonly IBookRepository _bookRepository;
    public BookDataProvider(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    private BookModel getModel(Book entity)
    {
        return new BookModel(
            entity.Id,
            entity.ISBN,
            entity.Title,
            entity.Author,
            entity.Publisher,
            entity.Publication_date,
            entity.Location,
            entity.Description,
            entity.Copies.Count()
            );
    }
    public ICollection<BookModel> getAll()
    {
        List<BookModel> result = new();
        foreach (var item in _bookRepository.FindAll())
        {
            result.Add(getModel(item));
        };
        return result;
    }
    public BookModel getById(int id)
    {
        return getModel(_bookRepository.FindByIdOrThrow(id));
    }
}
