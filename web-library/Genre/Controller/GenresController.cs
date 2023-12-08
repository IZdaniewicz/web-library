using Microsoft.AspNetCore.Mvc;

namespace web_library.Genre.Controller
{
    using web_library.Genre.Request;
    using web_library.Genre.Service;

    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateGenreRequest request)
        {
            try
            {
                _genreService.createGenre(request);
                return Ok();
            }
            catch
            (Exception)
            {
                return BadRequest();
            }
        }
    }
}
