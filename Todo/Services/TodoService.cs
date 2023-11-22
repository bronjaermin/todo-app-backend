using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Interfaces;

namespace Todo.Services
{
    public class TodoService : ITodoService
    {
        private readonly DatabaseContext _databaseContext;

        public TodoService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task CreateTodo(Item todo)
        {
            await _databaseContext.Items.AddAsync(todo);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _databaseContext.Items.Include(x => x.Categories).Include(x => x.User).ToListAsync();
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            return await _databaseContext.Items.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateTodoAsync(Item todo)
        {
            _databaseContext.Update(todo);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
