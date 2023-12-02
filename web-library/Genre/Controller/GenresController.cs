﻿using Microsoft.AspNetCore.Mvc;

namespace web_library.Genre.Controller
{
    using Microsoft.AspNetCore.Authorization;
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

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post([FromBody] CreateGenreRequest request)
        {
            try
            {
                _genreService.createGenre(request);
            }
            catch
            (Exception)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}