using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApiDataContext : DbContext
    {
        public ApiDataContext(DbContextOptions<ApiDataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // 1/18/2022,4:52 PM,Ferrel,Blogspan,Industrial Machinery/Components,10,1,494
        //private static List<Todo> ReadTodosFromCsv(string fileName)
        //{
        //    string[] formats = { "hhmm", "hmm", @"hh\:mm", @"h\:mm\:ss", @"h\:mm", "hh:mm tt", "h:mm tt" };
        //    var data = File.ReadAllLines(fileName);

        //    List<Todo> todos = new List<Todo>();
        //    foreach(var x in data.Skip(1).Select(x => x.Split(',')))
        //    {
        //        try
        //        {
        //            var TodoId = 0;
        //            var DueDate = DateTime.Parse(x[0]).Add(DateTime.ParseExact(x[1], formats, CultureInfo.CurrentCulture, DateTimeStyles.None).TimeOfDay);
        //            if (DueDate.Month < 10)
        //                DueDate.AddMonths(10 - DueDate.Month);
                    
        //            var Title = $"Meeting with {x[2]}";
        //            var Description = $"Meeting with {x[2]} at {x[3]} about {x[4]}";
        //            var CategoryId = int.Parse(x[5]);
        //            var PriorityId = int.Parse(x[6]);
        //            var UserId = int.Parse(x[7]);

        //            Random rnd = new Random();
        //            int daysDue = rnd.Next(1, 7);
        //            todos.Add(new Todo
        //            {
        //                TodoId = TodoId,
        //                CreatedDate = DueDate,
        //                DueDate = DueDate.AddDays(7),
        //                Description = Description,
        //                Title = Title,
        //                CategoryId = CategoryId,
        //                PriorityId = PriorityId,
        //                UserId = UserId
        //            });
        //        } catch { }
        //    }

        //    return todos;
        //}

        //public static async Task CheckAndSeedDatabaseAsync(ApiDataContext context)
        //{
        //    var currentCategories = context.Categories;
        //    if (currentCategories == null || currentCategories?.Count() == 0)
        //    {
        //        var categories = Seed.GetCategories();
        //        if (categories != null)
        //        {
        //            context.Categories.AddRange(categories);
        //            await context.SaveChangesAsync();
        //        }
        //    }

        //    var currentPriorities = context.Priorities;
        //    if (currentPriorities == null || currentPriorities?.Count() == 0)
        //    {
        //        var priorities = Seed.GetPriorities();
        //        if (priorities != null)
        //        {
        //            context.Priorities.AddRange(priorities);
        //            await context.SaveChangesAsync();
        //        }
        //    }

        //    var currentUsers = context.Users;
        //    if (currentUsers == null || currentUsers?.Count() == 0)
        //    {
        //        var users = Seed.GetUsers();
        //        if (users != null)
        //        {
        //            context.Users.AddRange(users);
        //            await context.SaveChangesAsync();
        //        }
        //    }

        //    var currentTodos = context.Todos;
        //    if (currentTodos == null || currentTodos?.Count() == 0)
        //    {
        //        await ReadAndImport(context, "todolist1.csv");
        //        await ReadAndImport(context, "todolist2.csv");
        //        await ReadAndImport(context, "todolist3.csv");
        //        await ReadAndImport(context, "todolist4.csv");
        //        await ReadAndImport(context, "todolist5.csv");
        //        await ReadAndImport(context, "todolist6.csv");
        //        await ReadAndImport(context, "todolist7.csv");
        //        await ReadAndImport(context, "todolist8.csv");
        //        await ReadAndImport(context, "todolist9.csv");
        //        await ReadAndImport(context, "todolist10.csv");
        //    }

        //}

        //private static async Task ReadAndImport(ApiDataContext context, string fileName)
        //{
        //    var todos = ReadTodosFromCsv(fileName);
        //    foreach (var todo in todos)
        //    {
        //        try
        //        {
        //            context.Todos.Add(todo);
        //            await context.SaveChangesAsync();
        //        }
        //        catch { }

        //    }
        //}
    }

}
