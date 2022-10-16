namespace Domain
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Todo> Todos { get; set; } = new List<Todo>();
    }
}
