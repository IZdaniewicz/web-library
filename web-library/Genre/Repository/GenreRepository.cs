namespace web_library.Genre.Repository
{
    using Entity;
    using web_library.Shared;

    public class GenreRepository :  IGenreRepository
    {
        private readonly DataContext _context;
        public GenreRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Genre entity)
        {
            _context.Genres.Add(entity);
            _context.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Genre> GetAll()
        {
            throw new NotImplementedException();
        }

        public Genre GetByIdOrThrow(int id)
        {
            Genre? genre = _context.Genres.Find(id) ?? throw new NotFoundException("Genre not found");
            return genre;
            throw new NotImplementedException();
        }

        public void Remove(Genre entity)
        {
            throw new NotImplementedException();
        }
    }
}
