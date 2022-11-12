using Domain;

namespace Data.GraphQL.Types
{
    // These GraphQL types are used for User mutations
    //
    public record UserInput(
        int UserId,
        string? FirstName,
        string? LastName
    );

    public record UserPayload(
        User user
    );
}
