using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using web_library.User.Repository;

namespace web_library.User.Service;
using Entity;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public void RegisterUser(string email, string password)
    {
        if (_userRepository.FindByEmail(email) != null)
        {
            throw new Exception("Email already taken!");
        }

        string hashedPassword = HashPassword(password);

        _userRepository.Add(new User(email, hashedPassword));
    }

    public ActionResult AuthenticateUser(User request)
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