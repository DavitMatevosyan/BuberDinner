using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Services.Authentication.Commands;

public record RegisterCommand(string firstName,
                              string lastName,
                              string email,
                              string password) : IRequest<ErrorOr<AuthenticationResult>>;
