using web_library.Role.Enum;

namespace web_library.User.Service;

public interface IUserService
{
    Entity.User GetUser();
    bool HasRole(Entity.User user, Roles role);
}