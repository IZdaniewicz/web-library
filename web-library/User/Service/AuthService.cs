using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using web_library.User.Repository;
using web_library.User.Request;

namespace web_library.User.Service;
using Entity;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserBasicInfoRepository _userBasicInfoRepository;
    private readonly IConfiguration _configuration;

    public AuthService(
        IUserRepository userRepository,
        IConfiguration configuration,
        IUserBasicInfoRepository userBasicInfo
        )
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _userBasicInfoRepository = userBasicInfo;
    }

    public void RegisterUser(RegisterUserRequest request)
    {
        if (_userRepository.FindByEmail(request.Email) != null)
        {
            throw new Exception("Email already taken!");
        }

        string hashedPassword = HashPassword(request.Password);

        var user = new User(request.Email, hashedPassword);

        _userRepository.Add(user);

        _userBasicInfoRepository.Add(new UserBasicInfo(
            user.Id,
            request.FirstName,
            request.LastName,
            request.PhoneNumber,
            request.Address,
            user
        ));


    }

    public ActionResult AuthenticateUser(LoginUserRequest request)
    {
        try
        {
            User? user = _userRepository.FindByEmail(request.Email);

            if (user != null && VerifyPassword(request.Password, user.Password))
            {
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti,
                            Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(5),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var stringToken = tokenHandler.WriteToken(token);

                return new OkObjectResult(stringToken);
            }

            return new UnauthorizedObjectResult("Bad credentials!");
        }
        catch (Exception e)
        {
            return new StatusCodeResult(StatusCodes.Status400BadRequest);
        }
    }


    private string HashPassword(string password)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt();

        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

        return hashedPassword;
    }

    private bool VerifyPassword(string enteredPassword, string hashedPassword)
    {
        try
        {
            // Verify the entered password against the stored hashed password
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }
        catch (CryptographicException)
        {
            return false;
        }
    }
}