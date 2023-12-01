using web_library.Shared;

namespace web_library.User.Repository;
using Entity;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dbContext;

    public UserRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public User GetByIdOrThrow(int id)
    {
        User? user =  _dbContext.Users.Find(id);

        if (user == null)
            throw new AlreadyExistsException("Email is taken");
        
        return user;
    }

    public User? FindByEmail(string email)
    {
        return _dbContext.Users.SingleOrDefault(user => user.Email == email);
    }

    public IEnumerable<User> GetAll()
    {
        return _dbContext.Users.ToList();
    }

    public void Add(User entity)
    {
        _dbContext.Users.Add(entity);
        _dbContext.SaveChanges();
    }

    public void Remove(User entity)
    {
        _dbContext.Users.Remove(entity);
        _dbContext.SaveChanges();
    }
}