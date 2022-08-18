using System.Text.Json.Serialization;

namespace DisneyMovies.Core.Entities;

public class Genre : BaseEntity
{
    public string? Name { get; set; }
    public string? ImgUrl { get; set; }
    public virtual ICollection<Media>? Medias { get; set; }
}