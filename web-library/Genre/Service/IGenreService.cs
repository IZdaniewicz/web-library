using web_library.Genre.Request;

namespace web_library.Genre.Service
{
    public interface IGenreService
    {
        void createGenre(CreateGenreRequest request);
    }
}