namespace web_library.User.Repository;
using Entity;
using web_library.User.Entity;

public interface IUserRepository : IGenericRepository<User>
{
    public User? FindByEmail(string email);
}