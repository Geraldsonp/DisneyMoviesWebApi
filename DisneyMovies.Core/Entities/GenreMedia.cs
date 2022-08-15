namespace DisneyMovies.Core.Entities;

public class GenreMedia
{
    public int GenreId { get; set; }
    public virtual Genre? Genre { get; set; }
    public int MediaId { get; set; }
    public virtual Media? Media { get; set; }
}