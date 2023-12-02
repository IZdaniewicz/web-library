using Newtonsoft.Json;
using web_library.Genre.Repository;
using web_library.Genre.Request;

namespace web_library.Genre.Service
{
    using Entity;
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

            Genre? entity = JsonConvert.DeserializeObject<Genre>(jsonString) ?? throw new NotImplementedException();

            _genreRepository.Add(entity);
            return;
        }
    }
}
