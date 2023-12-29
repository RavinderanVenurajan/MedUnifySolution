
using DataModel.Models;
using MedUnifyApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedUnifyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private readonly MedUnifyContext _context;

        public LoginController(IConfiguration config, MedUnifyContext context)
        {
            _config = config;
            _context = context;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(userInfo.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
              //  new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
                //new Claim("DateOfJoing", userInfo.DateOfJoing.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost("adduser")]
        public async Task<IActionResult> AddUser([FromBody] User createUserModel)
        {
            // Validate input model if needed

            var newUser = new User
            {
                Username = createUserModel.Username,
                Password = createUserModel.Password,
                SecretKey = createUserModel.SecretKey,
                OrganizationId = createUserModel.OrganizationId,
                // Other properties as needed
            };

            _context.User.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(newUser);
        }

        [HttpDelete("delete/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            // Authenticate and authorize the request (you may use [Authorize] attribute).
            // Check if the user has the necessary permissions to delete a user.

            var userToDelete = _context.User.Find(userId);

            if (userToDelete == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            _context.User.Remove(userToDelete);
            _context.SaveChanges();

            return Ok($"User with ID {userId} deleted successfully.");
        }

        private User AuthenticateUser(LoginModel login)
        {
            User user = null;

            //Validate the User Credentials
             var userdet = _context.User
           .FirstOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);
            if (userdet != null)
            {
                // Validation successful, return the SecretKey
                user = new User { Username = login.Username, SecretKey = userdet.Result.SecretKey };
                return user;
            }
            //if ((login.Username == "Admin")&&(login.Password=="Password1"))
            //{
            //   // user = new User { Username = login.Username, EmailAddress = "Admin@gmail.com", DateOfJoing = new DateTime(2010, 08, 02) };
            //}
            return user;
        }
    }
}
