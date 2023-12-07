using Todo.Data;

namespace Todo.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        string GenerateToken(User user);
        string HashPassword(string password);
        Task AddUserToRole(User user);
        Task RegisterUser(User user);
        Task CreateRole(UserRole role);
    }
}
