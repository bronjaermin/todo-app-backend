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
            return await _databaseContext.Items.ToListAsync();
        }
    }
}
