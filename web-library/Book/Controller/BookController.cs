using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_library.Book.Controller
{
    using Entity;
    using web_library.Book.Request;
    using web_library.Book.Service;

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateBookRequest request)
        {
            _bookService.createBook(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AssigneGenreToBookRequest request)
        {
            request.book_id = id;
            _bookService.assigneGenre(request);
            return Ok();
        }
    }
}
