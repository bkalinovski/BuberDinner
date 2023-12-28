using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

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
        var authResult = _authenticationService.Register(
            request.Firstname, 
            request.Lastname, 
            request.Email, 
            request.Password);

        return authResult.Match(
            response => Ok(MapAuthResponse(response)),
            Problem);
    }
    
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Email, request.Password);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);
        }
        
        return authResult.Match(
            response => Ok(MapAuthResponse(response)),
            Problem);
    }

    private AuthenticationResponse MapAuthResponse(AuthenticationResult result)
    {
        return new AuthenticationResponse(
            result.User.Id,
            result.User.FirstName,
            result.User.LastName,
            result.User.Email,
            result.Token);
    }
}