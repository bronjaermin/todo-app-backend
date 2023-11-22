using Todo.Data;

namespace Todo.Interfaces
{
    public interface ITodoService
    {
        Task<List<Item>> GetAllAsync();
        Task<Item> GetByIdAsync(int id);
        Task CreateTodo(Item todo);
        Task UpdateTodoAsync(Item todo);
    }
}
