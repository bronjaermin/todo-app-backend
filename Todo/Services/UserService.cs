using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Interfaces;

namespace Todo.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _databaseContext;

        public UserService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _databaseContext.Users.ToListAsync();
        }
    }
}
