namespace DisneyMovies.Infrastructure.Authentication;

public class JwtSettings
{
    public string? SecretKey { get; init; }
    public string? Issuer { get; init; }
    public int ExpirationTimeInMinutes { get; init; }
}