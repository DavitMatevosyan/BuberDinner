using BuberDinner.Application.Common.Interfaces;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;

    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not User user) 
            // throw new Exception("User with the email does not exist");
            return Errors.Auth.InvalidCredentials;

        if(user.Password != password)
            // throw new Exception("Invalid password");
            return Errors.Auth.InvalidCredentials;

        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(user, token);
    }

}
