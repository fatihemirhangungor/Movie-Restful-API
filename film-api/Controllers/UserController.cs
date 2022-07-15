using film_api.data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace film_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Basic user login with parameters -> name, password
        /// Creates a new user with given parameters and generates a token
        /// Nothing kept
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpGet("login")]
        public string Login(string UserName, string Password)
        {
            User user = new User(UserName, Password);
            if (user != null)
            {
                return GenerateToken(user.UserName);
            }
            return "";
        }

        /// <summary>
        /// Method for generating JWT token
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private string GenerateToken(string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Application:JWTSecret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "ARVATO",
                Issuer = "ARVATO.Issuer.Development",
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name, userName),
                }),

                
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
