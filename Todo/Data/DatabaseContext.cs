using Microsoft.EntityFrameworkCore;

namespace Todo.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
    }
}
