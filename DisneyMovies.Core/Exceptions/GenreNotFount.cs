namespace DisneyMovies.Core.Exceptions;

public class GenreNotFount : NotFountException
{
    public GenreNotFount(int genreID): base($"The Genre with the id {genreID} does not exist in the database")
    {
        
    }
}