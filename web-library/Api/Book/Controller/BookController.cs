using Microsoft.AspNetCore.Mvc;

namespace web_library.Api.Book.Controller;

using DataProvider;
using Request;
using Service;
using Model;

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

    [HttpGet]
    public ActionResult<IEnumerable<BookModel>> Index()
    {
        return Ok(_bookDataProvider.getAll());
    }

    [HttpGet("{id}")]
    public ActionResult<BookModel> Index(int id)
    {
        
        return Ok(_bookDataProvider.getById(id));
    }

    // POST api/<ValuesController>
    [HttpPost]
    public ActionResult Create([FromBody] CreateBookRequest request)
    {
        try
        {
            _bookService.createBook(request);
        }
        catch
        (Exception)
        {
            return NotFound();
        }
        return Ok();
    }

    // SEED
    [HttpPost("seed")]
    public ActionResult Seed(CreateBookRequest request)
    {

            CreateBookRequest bookRequest = new CreateBookRequest("random");
            _bookService.createBook(bookRequest);
    
        return Ok();
    }
}

