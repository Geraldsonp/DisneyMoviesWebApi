using DisneyMovies.Application.Authentication.Common;
using DisneyMovies.Application.DataTransferObjects;
using DisneyMovies.Application.Services;

namespace DisneyMovies.Application.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Register(RegisterRequest request);
    AuthenticationResult LogIn(LogInRequest request);
}