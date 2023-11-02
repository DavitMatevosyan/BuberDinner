using BuberDinner.Application.Common.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;
using MediatR;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using BuberDinner.Application.Common.Interfaces;

namespace BuberDinner.Application.Services.Authentication.Queries.Queries;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;


    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;

    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
                if(_userRepository.GetUserByEmail(request.Email) is not User user) 
            // throw new Exception("User with the email does not exist");
            return Errors.Auth.InvalidCredentials;

        if(user.Password != request.Password)
            // throw new Exception("Invalid password");
            return Errors.Auth.InvalidCredentials;

        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(user, token);
    }
}
