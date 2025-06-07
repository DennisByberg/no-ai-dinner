using Microsoft.AspNetCore.Mvc;
using NoAiDinner.Application.Services.Authentication;
using NoAiDinner.Contracts.Authentication;

namespace NoAiDinner.Api.Controllers;

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
        var authResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );

        var response = new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token
        );

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest)
    {
        var authResult = _authenticationService.Login(
            loginRequest.Email,
            loginRequest.Password
        );

        var response = new AuthenticationResponse(
           authResult.Id,
           authResult.FirstName,
           authResult.LastName,
           authResult.Email,
           authResult.Token
       );

        return Ok(response);
    }
}