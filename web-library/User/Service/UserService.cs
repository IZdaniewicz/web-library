using System.Security.Claims;
using web_library.Role.Enum;
using web_library.Role.Repository;
using web_library.User.Repository;

namespace web_library.User.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public Entity.User GetUser()
    {
        var email = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);

        if (email == null)
        {
            throw new UnauthorizedAccessException();
        }

        return _userRepository.FindByEmail(email);
    }

    public bool HasRole(Entity.User user, Roles role)
    {
        return (user.RoleId == role.GetValue());
    }
}