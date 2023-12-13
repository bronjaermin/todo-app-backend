using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.DTOs;
using Todo.Interfaces;

namespace Todo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsers() =>
            Ok(_mapper.Map<List<UserResponseDTO>>(await _userService.GetAllUsersAsync()));

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequestDTO request)
        {
            var userExist = await _userService.GetUserByUsername(request.UserName);

            if (userExist is not null)
                return BadRequest(new ErrorResponseDTO
                {
                    Message = "User already exist"
                });

            var user = _mapper.Map<User>(request);
            user.Password = _userService.HashPassword(request.Password);

            await _userService.RegisterUser(user);

            await _userService.CreateRole(new UserRole
            {
                Name = "User",
                UserId = user.Id
            });

            var token = _userService.GenerateToken(user);

            return Ok(new AuthResponseDTO
            {
                Token = token,
                User = _mapper.Map<UserResponseDTO>(user)
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody]LoginUserRequestDTO request)
        {
            var userExist = await _userService.GetUserByUsername(request.UserName);

            if (userExist is null)
                return NotFound(new ErrorResponseDTO
                {
                    Message = "User not registered in app"
                });

            if (userExist.Password != _userService.HashPassword(request.Password))
                return BadRequest(new ErrorResponseDTO
                {
                    Message = "Wrong password!"
                });

            var token = _userService.GenerateToken(userExist);

            return Ok(new AuthResponseDTO
            {
                Token = token,
                User = _mapper.Map<UserResponseDTO>(userExist)
            });
        }
    }
}
