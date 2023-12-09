using System.Collections.Generic;

namespace web_library;

public interface IGenericRepository<T> where T : class
{
    T FindByIdOrThrow(int id);
    IEnumerable<T> FindAll();
    void Add(T entity);
    void Remove(T entity);
}