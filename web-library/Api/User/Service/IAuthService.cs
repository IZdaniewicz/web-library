using Microsoft.AspNetCore.Mvc;
using web_library.Api.User.Request;

namespace web_library.Api.User.Service
{
    public interface IAuthService
    {
        ActionResult AuthenticateUser(LoginUserRequest request);
        void RegisterUser(RegisterUserRequest request);
    }
}