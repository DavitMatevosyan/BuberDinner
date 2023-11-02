using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password); //(LoginRequest request);
}
