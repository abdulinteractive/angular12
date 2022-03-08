using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service.IRepository;

namespace AngularProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userRepository.GetUsers();
            return Ok(users);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> GetUser(User luser)
        {
            var user = await userRepository.GetUser(luser.UserId);
            if(user==null)
            {
                return NotFound(new CommonResponse {StatusCode=StatusCodes.Status404NotFound, Success=false ,Message=$"This user {luser} does not exist" });
            }
            else if (user.Password != luser.Password)
            {
                return BadRequest(new CommonResponse { StatusCode = StatusCodes.Status400BadRequest, Success = false, Message = $"Please check your password and enter again valid password." });
            }
            return Ok(new CommonResponse {StatusCode=StatusCodes.Status200OK, Success=true,Message="Data found.",Data=user});
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            var users = await userRepository.AddUser(user);
            return Ok(users);
        }
    }
}
