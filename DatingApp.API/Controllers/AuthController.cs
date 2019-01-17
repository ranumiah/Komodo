using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    // Because we have [ApiController] we don't need to use [FromBody]
    //GET http://localhost:5000/api/auth
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto UserForRegisterDto)
        {
            // validate request

            UserForRegisterDto.Username = UserForRegisterDto.Username.ToLower();

            if (await _repo.UserExists(UserForRegisterDto.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = UserForRegisterDto.Username
            };

            var createdUser = await _repo.Register(userToCreate, UserForRegisterDto.Password);

            return StatusCode(201);
        }
    }
}