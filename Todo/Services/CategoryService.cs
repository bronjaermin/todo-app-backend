using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Interfaces;

namespace Todo.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DatabaseContext _databaseContext;

        public CategoryService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _databaseContext.Categories.AddAsync(category);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            _databaseContext.Categories.Remove(category);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _databaseContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdCategoryAsync(int id)
        {
            return await _databaseContext.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _databaseContext.Categories.Update(category);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
