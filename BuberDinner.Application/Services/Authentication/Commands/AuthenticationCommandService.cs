using BuberDinner.Application.Common.Interfaces;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Commands.Authentication;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;

    }


    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not null)
            // throw new DuplicateEmailException();
            // throw new Exception("User with given email already exists");
            // return Result.Fail<AuthenticationResult>(new DuplicateEmailError());
            return Errors.User.DuplicateError;

        var user  = new User() 
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
