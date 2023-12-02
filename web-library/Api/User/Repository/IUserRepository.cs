namespace web_library.Api.User.Repository;
using Entity;
using web_library.Api.User.Entity;

public interface IUserRepository : IGenericRepository<User>
{
    public User? FindByEmail(string email);
}