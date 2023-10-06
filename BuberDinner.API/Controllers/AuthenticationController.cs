using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace BuberDinner.API.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request) 
    {
        // var result = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        var authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        // if(registerResult .IsT0) {
        //     var result = registerResult.AsT0;
            
        //     var response = new AuthenticationResponse(
        //         result.User.Id,
        //         result.User.FirstName,
        //         result.User.LastName,
        //         result.User.Email,
        //         result.Token
        //     );
            
        //     return Ok(response);
        // }
        // return Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already Exists");

        // or
        return authResult.Match(
            authResult => Ok(MapAuthResponse(authResult)),
            errors => Problem(errors)
        );

        // if(registerResult.IsSuccess) {
        //     return Ok(MapAuthResponse(registerResult.Value));
        // }



        // return registerResult.Match(
        //     result => Ok(MapAuthResponse(result)),
        //     error => Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already Exists")
        // );
    }

    private static AuthenticationResponse MapAuthResponse(AuthenticationResult authResult) {
        return new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token
            );
    }


    [HttpPost("login")]
    public IActionResult Login(LoginRequest request) 
    {
        var result = _authenticationService.Login(request.Email, request.Password);
        
        if(result.IsError && result.FirstError == Errors.Auth.InvalidCredentials) {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: result.FirstError.Description
            );
        }

        var loginResult = new AuthenticationResponse(
            result.Value.User.Id,
            result.Value.User.FirstName,
            result.Value.User.LastName,
            result.Value.User.Email,
            result.Value.Token
        );

        return Ok(loginResult);
    }
}
