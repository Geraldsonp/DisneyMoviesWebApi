using DisneyMovies.Application.Authentication;
using DisneyMovies.Application.Authentication.Common;
using DisneyMovies.Application.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace DisneyMovies.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class Auth : Controller
{
    private readonly IAuthenticationService _authenticationService;

    public Auth(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    // Post - Api/auth/register
    [Route("register")]
    [HttpPost]
    public IActionResult Register(RegisterRequest request)
    {
        var result = _authenticationService.Register(request);
        if (!result.IsSuccess)
        {
            return BadRequest();
        }
        return Ok($"Token: {result.Token}");
    }
    
    //Api/auth/LogIn
    [Route("login")]
    [HttpPost]
    public IActionResult LogIn(LogInRequest request)
    {
        var result = _authenticationService.LogIn(request);

        if (result.IsSuccess)
        {
            return Ok($"Token: {result.Token}");
        }
        
        return BadRequest(result.Token);
    }
}