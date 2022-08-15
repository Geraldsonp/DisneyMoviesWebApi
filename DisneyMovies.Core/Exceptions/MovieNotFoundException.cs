namespace DisneyMovies.Core.Exceptions;

public class MovieNotFoundException : NotFountException
{
    public MovieNotFoundException(int movieId): 
        base($"The movie with the Id {movieId} does not exist in the database")
    {
        
    }
    
}