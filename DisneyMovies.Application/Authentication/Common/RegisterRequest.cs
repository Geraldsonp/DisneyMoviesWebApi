using System.ComponentModel.DataAnnotations;

namespace DisneyMovies.Application.DataTransferObjects;

public class RegisterRequest
{
    [Required]
    public string? Name { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    [Required, DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Required]
    public string? UserName { get; set; }
}