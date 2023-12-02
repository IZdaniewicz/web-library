using Newtonsoft.Json;
using web_library.Genre.Repository;
using web_library.Genre.Request;

namespace web_library.Genre.Service
{
    using Entity;
    using Newtonsoft.Json;

    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public void createGenre(CreateGenreRequest request)
        {
            var jsonString = JsonConvert.SerializeObject(request);

            Genre? genre = JsonConvert.DeserializeObject<Genre>(jsonString) ?? throw new JsonException();

            _genreRepository.Add(genre);
        }
    }
}
