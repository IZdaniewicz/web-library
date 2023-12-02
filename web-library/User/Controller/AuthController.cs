using Microsoft.AspNetCore.Authorization;
using web_library.User.Request;
using web_library.User.Service;

namespace web_library.User.Controller;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
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
}