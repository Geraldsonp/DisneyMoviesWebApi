using System.ComponentModel.DataAnnotations;

namespace DisneyMovies.Application.Authentication.Common;

public class LogInRequest
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
}