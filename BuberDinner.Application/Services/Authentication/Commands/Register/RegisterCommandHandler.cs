

using BuberDinner.Application.Common.Interfaces;
using BuberDinner.Application.Common.Persistence;
using ErrorOr;
using MediatR;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;


namespace BuberDinner.Application.Services.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if(_userRepository.GetUserByEmail(request.email) is not null)
            // throw new DuplicateEmailException();
            // throw new Exception("User with given email already exists");
            // return Result.Fail<AuthenticationResult>(new DuplicateEmailError());
            return Errors.User.DuplicateError; 

        var user  = new User() 
        {
            FirstName = request.firstName,
            LastName = request.lastName,
            Email = request.email,
            Password = request.password
        };

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);    
    }
}
