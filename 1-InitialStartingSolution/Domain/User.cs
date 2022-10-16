namespace Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = String.Empty;

        public ICollection<Todo> Todos { get; set; } = new List<Todo>();

    }
}
