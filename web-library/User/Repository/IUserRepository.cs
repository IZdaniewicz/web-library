namespace web_library.User.Repository;
using Entity;

public interface IUserRepository : IGenericRepository<User>
{
    public User? FindByEmail(string email);
}