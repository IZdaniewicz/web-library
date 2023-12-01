using Microsoft.AspNetCore.Mvc;

namespace web_library.User.Service;
using Entity;

public interface IAuthService
{
    void RegisterUser(string email, string password);
    ActionResult AuthenticateUser(User request);
}