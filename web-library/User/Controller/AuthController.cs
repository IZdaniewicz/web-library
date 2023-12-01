using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using web_library.User.Repository;
using web_library.User.Service;

namespace web_library.User.Controller;
using Microsoft.AspNetCore.Mvc;
using Entity;


[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public AuthController(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public ActionResult RegisterUser([FromBody] User user)
    {
        try
        {
            _authService.RegisterUser(user.Email, user.Password);
            return StatusCode(StatusCodes.Status201Created, "User succesfully registered");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
        }
    }
    
    [HttpPost("login")]
    [AllowAnonymous]
    public ActionResult AuthenticateUser([FromBody] User request)
    {
        return _authService.AuthenticateUser(request);
    }
}