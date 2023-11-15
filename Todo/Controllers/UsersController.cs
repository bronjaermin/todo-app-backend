using Microsoft.AspNetCore.Mvc;
using Todo.Interfaces;

namespace Todo.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public UsersController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("api/users")]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _todoService.GetAllAsync();
            return Ok(todos);
        }
    }
}
