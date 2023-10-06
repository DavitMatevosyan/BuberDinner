using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Auth 
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "Authentication.InvalidCredentials", 
            description: "Invalid Credentials");
    }
}
