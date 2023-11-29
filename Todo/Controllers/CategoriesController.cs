using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.DTOs;
using Todo.Interfaces;

namespace Todo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories() =>
            Ok(_mapper.Map<List<CategoryResponseDTO>>(await _categoryService.GetAllCategoriesAsync()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCategory([FromRoute]int id)
        {
            var category = await _categoryService.GetByIdCategoryAsync(id);

            if (category == null) return NotFound(new ErrorResponseDTO
            {
                Message = $"Category with id={id} not found"
            });

            return Ok(_mapper.Map<CategoryResponseDTO>(category));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryRequestDTO request)
        {
            var category = _mapper.Map<Category>(request);

            await _categoryService.CreateCategoryAsync(category);

            var categoryResponse = _mapper.Map<CategoryResponseDTO>(category);

            return Created("http://localhost:7000/api/Categories", categoryResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryRequestDTO request, [FromRoute]int id)
        {
            var category = await _categoryService.GetByIdCategoryAsync(id);

            if (category is null) return NotFound(new ErrorResponseDTO
            {
                Message = $"Category with id={id} not found"
            });

            _mapper.Map<CategoryRequestDTO, Category>(request, category);

            await _categoryService.UpdateCategoryAsync(category);

            return Ok(_mapper.Map<CategoryResponseDTO>(category));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute]int id)
        {
            var category = await _categoryService.GetByIdCategoryAsync(id);

            if (category == null) return NotFound(new ErrorResponseDTO
            {
                Message = $"Category with id={id} not found"
            });

            await _categoryService.DeleteCategoryAsync(category);

            return NoContent();
        }
    }
}
