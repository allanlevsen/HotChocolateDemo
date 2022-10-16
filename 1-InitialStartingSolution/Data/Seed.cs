using Domain;

namespace Data
{
    static public class Seed
    {
        static public List<User> GetUsers()
        {
            return new List<User>()
            {
                new User{ FirstName = "Allan", LastName = "Anderson" },
                new User{ FirstName = "Bob", LastName = "Barker" },
                new User{ FirstName = "Cathy", LastName = "Conner" },
                new User{ FirstName = "Darren", LastName = "Drake" },
                new User{ FirstName = "Edward", LastName = "Emmerson" },
                new User{ FirstName = "Frank", LastName = "Franklin" },
                new User{ FirstName = "Glenn", LastName = "Glovers" },
                new User{ FirstName = "Harry", LastName = "Henderson" }
            };
        }

        static public List<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category{ Name = "Personal", Description = "This Todo Category represents personnal todo items" },
                new Category{ Name = "Public", Description = "This Todo Category represents public todo items" },
                new Category{ Name = "Work", Description = "This Todo Category represents work related todo items" },
            };
        }

        static public List<Priority> GetPriorities()
        {
            return new List<Priority>()
            {
                new Priority{ Name = "General", Description = "This Todo Priority represents a general Priority" },
                new Priority{ Name = "Low", Description = "This Todo Priority represents a low Priority" },
                new Priority{ Name = "Medium", Description = "This Todo Priority represents a medium Priority" },
                new Priority{ Name = "High", Description = "This Todo Priority represents a high Priority" },
                new Priority{ Name = "Urgent", Description = "This Todo Priority represents a urgent Priority" },
            };
        }

        static public List<Todo> GetTodos(ApiDataContext context)
        {
            var users = context.Users.ToArray();
            var priorities = context.Priorities.ToArray();
            var categories = context.Categories.ToArray();
            return new List<Todo>()
            {
                new Todo{
                    Title = "Clean Garage",
                    Description = "Remove all of the junk, clean the floor, wash windows, and organize shelving",
                    CreatedDate = new DateTime(2022, 9, 4),
                    DueDate = new DateTime(2022, 9, 18),
                    UserId = users[0].UserId,
                    PriorityId = priorities[0].PriorityId,
                    CategoryId = categories[1].CategoryId
                },
                new Todo{
                    Title = "Complete Work Estimate",
                    Description = "Finish the software design estimate",
                    CreatedDate = new DateTime(2022, 9, 23),
                    DueDate = new DateTime(2022, 10, 4),
                    UserId = users[1].UserId,
                    PriorityId = priorities[3].PriorityId,
                    CategoryId = categories[2].CategoryId
                },
                new Todo{
                    Title = "Setup Accounting System",
                    Description = "Signup and configure new accounting software",
                    CreatedDate = new DateTime(2022, 9, 27),
                    DueDate = new DateTime(2022, 10, 1),
                    UserId = users[2].UserId,
                    PriorityId = priorities[4].PriorityId,
                    CategoryId = categories[0].CategoryId
                },
                new Todo{
                    Title = "Clear Garage",
                    Description = "Remove all of the junk",
                    CreatedDate = new DateTime(2022, 9, 5),
                    DueDate = new DateTime(2022, 9, 20),
                    UserId = users[1].UserId,
                    PriorityId = priorities[0].PriorityId,
                    CategoryId = categories[1].CategoryId
                },
                new Todo{
                    Title = "Work Proposal",
                    Description = "Hardware design proposal",
                    CreatedDate = new DateTime(2022, 9, 22),
                    DueDate = new DateTime(2022, 9, 26),
                    UserId = users[1].UserId,
                    PriorityId = priorities[2].PriorityId,
                    CategoryId = categories[1].CategoryId
                },
                new Todo{
                    Title = "Development System",
                    Description = "Configure new software",
                    CreatedDate = new DateTime(2022, 9, 24),
                    DueDate = new DateTime(2022, 9, 24),
                    UserId = users[2].UserId,
                    PriorityId = priorities[2].PriorityId,
                    CategoryId = categories[1].CategoryId
                }
            };
        }

    }
}
