using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_library.Book.Controller
{
    using Entity;
    using Request;
    using Service;
    using DataProvider;
    using Microsoft.AspNetCore.Authorization;

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IBookDataProvider _bookDataProvider;

        public BookController(IBookService bookService, IBookDataProvider bookDataProvider)
        {
            _bookService = bookService;
            _bookDataProvider = bookDataProvider;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return Ok(_bookDataProvider.getAll());
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] CreateBookRequest request)
        {
            _bookService.createBook(request);
            return Ok();
        }
        // POST api/<ValuesController>
        [HttpPost("seed")]
        public ActionResult Seed([FromBody] CreateBookRequest request)
        {
            request = new("seed");
            _bookService.createBook(request);
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AssigneGenreToBookRequest request)
        {
            request.book_id = id;
            _bookService.assigneGenre(request);
            return Ok();
        }
    }
}
