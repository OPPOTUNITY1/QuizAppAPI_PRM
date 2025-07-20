using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuizAppAPI_PRM.Data;
using QuizAppAPI_PRM.Models.Domain;
using QuizAppAPI_PRM.Models.DTO;
using QuizAppAPI_PRM.Repository.Interface;

namespace QuizAppAPI_PRM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // POST: api/User/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.PasswordHash))
                return BadRequest("Username and password are required.");

            var user = await userRepository.AuthenticateAsync(request.Username, request.PasswordHash);
            if (user == null)
                return Unauthorized("Invalid username or password.");

            var response = new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                RoleId = user.RoleId
            };

            return Ok(response);
        }

        // POST: api/User/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AddUserRequestDTO request)
        {
            var exists = await userRepository.UsernameExistsAsync(request.Username);
            if (exists)
                return BadRequest("Username already exists.");
            if (request.Username.IsNullOrEmpty() || request.PasswordHash.IsNullOrEmpty())
            {
                return BadRequest("Username and password cannot be empty.");
            }
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Username = request.Username,
                PasswordHash = request.PasswordHash,
                RoleId = Guid.Parse("28481261-dd77-4108-8817-4812cc951e93"), // thay id student o day nha
            };

            await userRepository.CreateAsync(user);

            var response = new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                RoleId = user.RoleId
            };

            return Ok(response);
        }

        // PUT: api/User/change-password
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO request)
        {
            var user = await userRepository.AuthenticateAsync(request.Username, request.OldPassword);
            if (user == null)
                return Unauthorized("Old password is incorrect.");

            user.PasswordHash = request.NewPassword;
            await userRepository.UpdateAsync(user);

            return Ok("Password updated successfully.");
        }
    }
}
