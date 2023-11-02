using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;

namespace BuberDinner.Application.Services.Commands.Authentication;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult>  Register(string firstName, string lastName, string email, string password); //(RegisterRequest request);
}
