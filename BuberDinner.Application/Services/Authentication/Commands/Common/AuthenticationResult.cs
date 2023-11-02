using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication.Commands;

public record AuthenticationResult(User User, string Token);
