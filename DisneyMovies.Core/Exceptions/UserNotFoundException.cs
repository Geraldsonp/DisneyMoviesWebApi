namespace DisneyMovies.Core.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("User With the Given Id Or Password Does not Exist")
    {
    }
}