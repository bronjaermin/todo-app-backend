using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Data
{
    public class Item
    {
        public int Id { get; set; }
        public string Content { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Category> Categories { get; set; }
    }
}
