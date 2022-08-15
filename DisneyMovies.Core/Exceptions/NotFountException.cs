namespace DisneyMovies.Core.Exceptions;

public abstract class NotFountException : Exception
{
    protected NotFountException( string message) : base(message)
    {
        
    }
}