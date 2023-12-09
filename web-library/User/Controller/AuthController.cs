using Microsoft.AspNetCore.Authorization;
<<<<<<< HEAD

namespace web_library.User.Controller;
using Microsoft.AspNetCore.Mvc;
using web_library.User.Request;
using web_library.User.Service;
=======
using Microsoft.AspNetCore.Mvc;
using web_library.Role.Enum;
using web_library.User.Request;
using web_library.User.Service;

namespace web_library.User.Controller;
>>>>>>> master

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;

    public AuthController(IAuthService authService, IUserService userService)
    {
        _authService = authService;
        _userService = userService;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public ActionResult RegisterUser([FromBody] RegisterUserRequest request)
    {
        try
        {
            _authService.RegisterUser(request);
            return StatusCode(StatusCodes.Status201Created, "User succesfully registered");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
        }
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public ActionResult AuthenticateUser([FromBody] LoginUserRequest request)
    {
        return _authService.AuthenticateUser(request);
    }

    [HttpGet("xd")]
    [Authorize]
    public ActionResult Xd()
    {
        var user = _userService.GetUser();
        return Ok(_userService.HasRole(user, Roles.Admin));
    }
}