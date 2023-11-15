using Todo.Data;

namespace Todo.Interfaces
{
    public interface ITodoService
    {
        Task<List<Item>> GetAllAsync();
        Task CreateTodo(Item todo);
    }
}
