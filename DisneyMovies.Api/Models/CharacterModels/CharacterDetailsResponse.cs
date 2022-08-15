using System.ComponentModel.DataAnnotations;
using DisneyMovies.Api.Models.MediaModels;
using DisneyMovies.Core.Entities;
using Mapster;

namespace DisneyMovies.Api.Models.CharacterModels;

public class CharacterDetailsResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ImgUrl { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public string? History { get; set; }
    public ICollection<MediaDetailsResponse>? Medias { get; set; }
}