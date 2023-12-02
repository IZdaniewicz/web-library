using Microsoft.AspNetCore.Mvc;
namespace web_library.Genre.Contoller
{
    using Service;
    using web_library.Genre.Request;

    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateGenreRequest request)
        {
            try
            {
                _genreService.createGenre(request);

            } catch (Exception) {
                return NotFound();
            }
            return Ok();
        }
    }
}
