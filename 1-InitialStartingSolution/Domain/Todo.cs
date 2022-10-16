using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Todo
    {
        public int TodoId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }

        public int PriorityId { get; set; }
        public Priority? Priority { get; set; } = null;

        public int CategoryId { get; set; }
        public Category? Category { get; set; } = null;

        public int UserId { get; set; }
        public User? User { get; set; } = null;
    }
}
