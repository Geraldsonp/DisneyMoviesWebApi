namespace DisneyMovies.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(int id, string firstName, string userName);
}