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
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public TodosController(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _todoService.GetAllAsync();
            var todosResponse = _mapper.Map<List<ItemResponseDTO>>(todos);
            return Ok(todosResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var todo = await _todoService.GetByIdAsync(id);

            if (todo == null) return NotFound(new ErrorResponseDTO
            {
                Message = $"Todo with id={id} not found"
            });

            return Ok(_mapper.Map<ItemResponseDTO>(todo));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ItemRequestDTO request)
        {
            var item = _mapper.Map<Item>(request);
            await _todoService.CreateTodo(item);

            return Created("http://localhost:7000/api/Todos", _mapper.Map<ItemResponseDTO>(item));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ItemUpdateRequestDTO request, [FromRoute] int id)
        {
            var itemFromDatabase = await _todoService.GetByIdAsync(id);

            if (itemFromDatabase == null)
            {
                return NotFound();
            }

            var item = _mapper.Map<ItemUpdateRequestDTO, Item>(request, itemFromDatabase);
            await _todoService.UpdateTodoAsync(item);

            return Ok(_mapper.Map<ItemResponseDTO>(item));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var todo = await _todoService.GetByIdAsync(id);

            if (todo == null) return NotFound(new ErrorResponseDTO
            {
                Message = $"Todo with id={id} not found"
            });

            await _todoService.DeleteTodoAsync(todo);

            return NoContent();
        }
    }
}
