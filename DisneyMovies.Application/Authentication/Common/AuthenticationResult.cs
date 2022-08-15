namespace DisneyMovies.Application.Services;

public class AuthenticationResult
{
    public bool IsSuccess { get; set; }
    public string? Token { get; set; }
}