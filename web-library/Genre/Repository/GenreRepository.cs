namespace web_library.Genre.Repository
{
    using Entity;
    using SharedExceptions;

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

        public IEnumerable<Genre> FindAll()
        {
            throw new NotImplementedException();
        }

        public Genre FindByIdOrThrow(int id)
        {
            Genre? genre = _context.Genres.Find(id) ?? throw new NotFoundException("Genre " + id + " not found in repository");
            return genre;
            throw new NotImplementedException();
        }

        public void Remove(Genre entity)
        {
            throw new NotImplementedException();
        }
    }
}
