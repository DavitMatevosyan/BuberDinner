using System.Net;
using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            IServiceException se => ((int)se.StatusCode, se.Message),
            _ => (StatusCodes.Status500InternalServerError, "An expected error occured"),
        };

        return Problem(statusCode: statusCode, title: message);
    }
}
