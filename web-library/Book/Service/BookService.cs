﻿using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using web_library.Book.DataProvider;
using web_library.Book.Entity;
using web_library.Book.Repository;
using web_library.Book.Request;
using web_library.Role.Enum;
using web_library.SharedExceptions;
using web_library.User.Service;

namespace web_library.Book.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookCopyRepository _bookCopyRepository;
        private readonly IUserService _userService;

        public BookService(IBookRepository bookRepository, IBookCopyRepository bookCopyRepository,
            IUserService userService)
        {
            _bookRepository = bookRepository;
            _bookCopyRepository = bookCopyRepository;
            _userService = userService;
        }

        [Authorize]
        public void createBook(CreateBookRequest request)
        {
            if (!_userService.HasRole(_userService.GetUser(), Roles.Librarian))
            {
                throw new UnauthorizedException();
            }

            var jsonString = JsonConvert.SerializeObject(request);

            Entity.Book? entity = JsonConvert.DeserializeObject<Entity.Book>(jsonString) ?? throw new JsonException();

            _bookRepository.Add(entity);

            for (int i = 0; i < request.NumberOfCopies; i++)
            {
                BookCopy copy = new(entity);
                _bookCopyRepository.Add(copy);
            }

            _bookRepository.Update(entity);
        }
    }
}