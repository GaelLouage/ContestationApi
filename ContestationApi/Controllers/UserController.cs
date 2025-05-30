using Infra.Dtos;
using Infra.Extensions;
using Infra.Helpers;
using Infra.Models;
using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContestationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMongoRepository<User> _userRepository;
        public UserController(IConfiguration config, IMongoRepository<User> userRepository)
        {
            _config = config;
            _userRepository = userRepository;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
          
            if (string.IsNullOrEmpty(user.UserName))
            {
                return NotFound("");
            }
            //verify password
            
            var userData = (await _userRepository.GetAllAsync())
                .FirstOrDefault( x => x.UserName == user.UserName);
            if(userData is null)
            {
                return BadRequest("Password or username is incorrect!");
            }
           
            var verifyPassword = user.Password.VerifyPassword(userData.Password);
            if(verifyPassword is false)
            {
                return BadRequest("Password or username is incorrect!");
            }
         
            var token = AuthHelpers.GenerateJWTToken(_config, userData);
            return Ok(token);
        }
    }
}
