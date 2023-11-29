using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllUsers() =>
            Ok(_mapper.Map<List<UserResponseDTO>>(await _userService.GetAllUsersAsync()));
    }
}
