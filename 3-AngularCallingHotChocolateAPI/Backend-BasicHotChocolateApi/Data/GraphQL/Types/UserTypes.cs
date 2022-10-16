using Domain;

namespace Data.GraphQL.Types
{
    public record UserInput(
        int UserId,
        string? FirstName,
        string? LastName
    );

    public record UserPayload(
        User user
    );
}
