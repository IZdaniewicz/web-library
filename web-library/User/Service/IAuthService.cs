using Microsoft.AspNetCore.Mvc;
using web_library.User.Request;

namespace web_library.User.Service
{
    public interface IAuthService
    {
        ActionResult AuthenticateUser(LoginUserRequest request);
        void RegisterUser(RegisterUserRequest request);
    }
}