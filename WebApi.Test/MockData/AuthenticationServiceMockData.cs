using DisneyMovies.Application.Services;

namespace WebApi.Test.MockData;

public class AuthenticationServiceMockData
{
    public AuthenticationResult GetValidResult()
    {
       return new AuthenticationResult()
        {
            IsSuccess = true,
            Token = "123456789"
        };
    }
    public AuthenticationResult GetInValidResult()
    {
        return new AuthenticationResult()
        {
            IsSuccess = false,
            Token = "123456789"
        };
    }
}