using web_library.SharedExceptions;

namespace web_library.Role.Repository;

public class RoleRepository : IRoleRepository
{
    private readonly DataContext _dbContext;

    public RoleRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Entity.Role GetByIdOrThrow(int id)
    {
        Entity.Role? role = _dbContext.Roles.Find(id);

        if (role == null)
            throw new NotFoundException("Role not found");

        return role;
    }

    public IEnumerable<Entity.Role> GetAll()
    {
        return _dbContext.Roles.ToList();
    }

    public void Add(Entity.Role entity)
    {
        _dbContext.Roles.Add(entity);
        _dbContext.SaveChanges();
    }

    public void Remove(Entity.Role entity)
    {
        _dbContext.Roles.Remove(entity);
        _dbContext.SaveChanges();
    }
}