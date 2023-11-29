using Microsoft.AspNetCore.Mvc;
using web_library.Book.Entity;
using web_library;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly DataContext _context;

        public BookController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            //return _context.Books.ToList();
            return Ok(_context.Books.Include(b => b.Copies).ToList());
        }
    }
}
