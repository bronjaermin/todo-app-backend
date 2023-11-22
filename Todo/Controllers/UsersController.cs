using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.DTOs;
using Todo.Interfaces;

namespace Todo.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public UsersController(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        [HttpGet("api/users")]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _todoService.GetAllAsync();
            var todosResponse = _mapper.Map<List<ItemResponseDTO>>(todos);
            return Ok(todosResponse);
        }

        [HttpPost("api/items")]
        public async Task<IActionResult> Create([FromBody] ItemRequestDTO request)
        {
            var item = _mapper.Map<Item>(request);
            await _todoService.CreateTodo(item);

            return Ok();
        }

        [HttpPut("api/items/{id}")]
        public async Task<IActionResult> Update([FromBody] ItemUpdateRequestDTO request, [FromRoute]int id)
        {
            var itemFromDatabase = await _todoService.GetByIdAsync(id);

            if(itemFromDatabase == null)
            {
                return NotFound();
            }

            var item = _mapper.Map<ItemUpdateRequestDTO, Item>(request, itemFromDatabase);
            await _todoService.UpdateTodoAsync(item);

            return Ok();
        }
    }
}
