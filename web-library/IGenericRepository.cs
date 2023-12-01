namespace web_library;

public interface IGenericRepository<T> where T : class
{
    T GetByIdOrThrow(int id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Remove(T entity);
}