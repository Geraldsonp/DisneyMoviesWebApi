using System.Text.Json.Serialization;

namespace DisneyMovies.Core.Entities;

public class Genre : BaseEntity
{
    public string? Name { get; set; }
    public string? ImgUrl { get; set; }
    [JsonIgnore]
    public virtual ICollection<GenreMedia>? GenreMedias { get; set; }
}