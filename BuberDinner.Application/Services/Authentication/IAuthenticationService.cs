namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Login(string email, string password); //(LoginRequest request);
    AuthenticationResult Register(string firstName, string lastName, string email, string password); //(RegisterRequest request);
}
