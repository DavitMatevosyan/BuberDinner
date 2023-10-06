using ErrorOr;
using FluentResults;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult>  Register(string firstName, string lastName, string email, string password); //(RegisterRequest request);
    ErrorOr<AuthenticationResult> Login(string email, string password); //(LoginRequest request);
}
