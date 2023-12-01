using Microsoft.AspNetCore.Mvc;
using web_library.User.Request;

namespace web_library.User.Service;
using Entity;

public interface IAuthService
{
    void RegisterUser(RegisterUserRequest request);
    ActionResult AuthenticateUser(User request);
}