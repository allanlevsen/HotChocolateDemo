using Domain;

namespace Data.GraphQL
{
    public class Query
    {
        // [UseDbContext() needed for parallel usage
        // in the DI on the method - we also need [ScopedService]

        [UseDbContext(typeof(ApiDataContext))]
        [UseProjection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<User> GetUsers([ScopedService] ApiDataContext context)
        {
            return context.Users;
        }

        [UseDbContext(typeof(ApiDataContext))]
        [UseProjection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<Category> GetCategories([ScopedService] ApiDataContext context)
        {
            return context.Categories;
        }

        [UseDbContext(typeof(ApiDataContext))]
        [UseProjection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<Priority> GetPriorities([ScopedService] ApiDataContext context)
        {
            return context.Priorities;
        }

        [UseDbContext(typeof(ApiDataContext))]
        [UseProjection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<Todo> GetTodos([ScopedService] ApiDataContext context)
        {
            return context.Todos;
        }
    }
}
