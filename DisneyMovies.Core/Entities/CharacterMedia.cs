namespace DisneyMovies.Core.Entities;

public class CharacterMedia
{
    public int CharacterId { get; set; }
    public virtual Character? Character { get; set; }
    public int MediaId { get; set; }
    public virtual Media? Media { get; set; }
}