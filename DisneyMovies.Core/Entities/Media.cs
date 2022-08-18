using System.ComponentModel.DataAnnotations;
using DisneyMovies.Core.Enums;

namespace DisneyMovies.Core.Entities;

public class Media : BaseEntity
{
    [Required(ErrorMessage = "Name can not be empty")]
    [DataType(DataType.Text), MinLength(3, ErrorMessage = "Character name Should be at least 3 characters")]
    public string? Title { get; set; }

    public string? ImgUrl { get; set; }

    [Required(ErrorMessage = "Duration is required"),
     DataType(DataType.Duration, ErrorMessage = "Enter a duration with format MM.SS")]
    public long DurationInMinutes { get; set; }

    [Required(ErrorMessage = "Date Created is should not be empty"), DataType(DataType.Date)]
    public DateTime CreationDate { get; set; }

    [Range(minimum: 1, maximum: 5)] public int Rating { get; set; }


    [Required] public MediaType Type { get; set; }
    public virtual ICollection<Character>? Characters { get; set; }
    public virtual ICollection<Genre>? Genres { get; set; }
}