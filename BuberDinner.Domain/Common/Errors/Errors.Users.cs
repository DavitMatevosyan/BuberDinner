using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class User 
    {
        public static Error DuplicateError => Error.Conflict(
            code: "User.DuplicateEmail", 
            description: "This email already exists");
    }
}
