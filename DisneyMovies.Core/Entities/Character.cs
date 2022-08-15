using System.ComponentModel.DataAnnotations;

namespace DisneyMovies.Core.Entities;

public class Character : BaseEntity
{
    [Required(ErrorMessage = "Name Should not be empty")]
    [DataType(DataType.Text)]
    public string? Name { get; set; }
    public string? ImgUrl { get; set; }
    [Required(ErrorMessage = "Age Should not be empty")]
    public int Age { get; set; }
    [Required]
    public double Weight { get; set; }
    [Required]
    [DataType(DataType.Text), MinLength(50)]
    public string? History { get; set; }

    public virtual ICollection<CharacterMedia>? CharactersMedias { get; set; }
}

