using System.ComponentModel.DataAnnotations;
using DisneyMovies.Api.Models.CharacterModels;
using DisneyMovies.Core.Entities;
using DisneyMovies.Core.Enums;

namespace DisneyMovies.Api.Models.MediaModels;

public class MediaDetailsResponse
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? ImgUrl { get; set; }
    public long DurationInMinutes { get; set; }
    public DateTime CreationDate { get; set; }
    public int Rating { get; set; }
    public MediaType Type { get; set; }
    public virtual ICollection<Genre>? Genres { get; set; }
    public ICollection<CharacterDetailsResponse> Characters { get; set; }
    
}