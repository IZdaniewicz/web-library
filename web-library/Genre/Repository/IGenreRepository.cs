




namespace web_library.Genre.Repository
{
    using Entity;
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        void Add(Entity.Genre entity);
        IEnumerable<Entity.Genre> GetAll();
        Entity.Genre GetByIdOrThrow(int id);
        void Remove(Entity.Genre entity);
    }
}