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

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return Ok();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] CreateBookRequest request)
        {
            try
            {
                _bookService.createBook(request);
            } catch
            (Exception)
            {
                return NotFound();
            }
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
