using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request) 
    {
        var result = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        var registerResult = new AuthenticationResponse(
            result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token
        );

        return Ok(registerResult);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request) 
    {
        var result = _authenticationService.Login(request.Email, request.Password);
        
        var loginResult = new AuthenticationResponse(
            result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token
        );

        return Ok(loginResult);
    }
}