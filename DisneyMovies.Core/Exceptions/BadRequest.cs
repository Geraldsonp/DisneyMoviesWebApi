namespace DisneyMovies.Core.Exceptions;

public abstract class BadRequest : Exception
{
    protected BadRequest(string message) : base(message)
    {
        
    }
}