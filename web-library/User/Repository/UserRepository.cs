using web_library.SharedExceptions;

namespace web_library.User.Repository;
<<<<<<< HEAD
using Entity;
using web_library.User.Entity;
=======
>>>>>>> master

public class UserRepository : IUserRepository
{
    private readonly DataContext _dbContext;

    public UserRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

<<<<<<< HEAD
    public User FindByIdOrThrow(int id)
=======
    public Entity.User GetByIdOrThrow(int id)
>>>>>>> master
    {
        Entity.User? user = _dbContext.Users.Find(id);

        if (user == null)
            throw new NotFoundException("User is not found");

        return user;
    }

    public Entity.User? FindByEmail(string email)
    {
        return _dbContext.Users.SingleOrDefault(user => user.Email == email);
    }

<<<<<<< HEAD
    public IEnumerable<User> FindAll()
=======
    public IEnumerable<Entity.User> GetAll()
>>>>>>> master
    {
        return _dbContext.Users.ToList();
    }

    public void Add(Entity.User entity)
    {
        _dbContext.Users.Add(entity);
        _dbContext.SaveChanges();
    }

    public void Remove(Entity.User entity)
    {
        _dbContext.Users.Remove(entity);
        _dbContext.SaveChanges();
    }
}