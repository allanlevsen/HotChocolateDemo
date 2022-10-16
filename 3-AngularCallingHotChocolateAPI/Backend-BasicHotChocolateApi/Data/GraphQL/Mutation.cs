using Data.GraphQL.Types;
using Domain;

namespace Data.GraphQL
{
    [GraphQLDescription("Represents the mutations available.")]
    public class Mutation
    {
        [UseDbContext(typeof(ApiDataContext))]
        [GraphQLDescription("Adds a user.")]
        public async Task<UserPayload> AddUserAsync(UserInput input,
            [ScopedService] ApiDataContext context)
        {
            var user = new User
            {
                UserId = input.UserId,
                FirstName = input.FirstName ?? "",
                LastName = input.LastName ?? ""
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return new UserPayload(user);
        }

        [UseDbContext(typeof(ApiDataContext))]
        [GraphQLDescription("Updates a user.")]
        public async Task<UserPayload> UpdateUserAsync(UserInput input,
            [ScopedService] ApiDataContext context)
        {
            User user = await context.Users.FindAsync(input.UserId);
            if (user != null)
            {
                if (!string.IsNullOrWhiteSpace(input.FirstName))
                    user.FirstName = input.FirstName;
                if (!string.IsNullOrWhiteSpace(input.LastName))
                    user.LastName = input.LastName;

                await context.SaveChangesAsync();
            }
            else
            {
                // return an empty object if nothing was updated
                //
                user = new User();
            }

            return new UserPayload(user);
        }

        [UseDbContext(typeof(ApiDataContext))]
        [GraphQLDescription("Deletes a user.")]
        public async Task<UserPayload> DeleteUserAsync(int userId,
            [ScopedService] ApiDataContext context)
        {
            User user = await context.Users.FindAsync(userId);
            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
            else
            {
                // return an empty object if user was not found to delete
                //
                user = new User();
            }

            return new UserPayload(user);
        }

    }
}
