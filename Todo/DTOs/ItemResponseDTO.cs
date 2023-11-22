namespace Todo.DTOs
{
    public class ItemResponseDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public UserResponseDTO User { get; set; }
        public List<CategoryResponseDTO> Categories { get; set; }
    }
}
