namespace web_library.Genre.Repository
{
    using Entity;
    public class GenreRepository :  IGenreRepository
    {
        private readonly DataContext _context;
        public GenreRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Genre entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Genre> GetAll()
        {
            throw new NotImplementedException();
        }

        public Genre GetByIdOrThrow(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Genre entity)
        {
            throw new NotImplementedException();
        }
    }
}
