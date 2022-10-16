using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApiDataContext : DbContext
    {
        public ApiDataContext(DbContextOptions<ApiDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Todo> Todos { get; set; }

        public static async Task CheckAndSeedDatabaseAsync(ApiDataContext context)
        {
            var currentCategories = context.Categories;
            if (currentCategories == null || currentCategories?.Count() == 0)
            {
                var categories = Seed.GetCategories();
                if (categories != null)
                {
                    context.Categories.AddRange(categories);
                    await context.SaveChangesAsync();
                }
            }

            var currentPriorities = context.Priorities;
            if (currentPriorities == null || currentPriorities?.Count() == 0)
            {
                var priorities = Seed.GetPriorities();
                if (priorities != null)
                {
                    context.Priorities.AddRange(priorities);
                    await context.SaveChangesAsync();
                }
            }

            var currentUsers = context.Users;
            if (currentUsers == null || currentUsers?.Count() == 0)
            {
                var users = Seed.GetUsers();
                if (users != null)
                {
                    context.Users.AddRange(users);
                    await context.SaveChangesAsync();
                }
            }

            var currentTodos = context.Todos;
            if (currentTodos == null || currentTodos?.Count() == 0)
            {
                var todos = Seed.GetTodos(context);
                if (todos != null)
                {
                    context.Todos.AddRange(todos);
                    await context.SaveChangesAsync();
                }
            }

        }

    }

}
