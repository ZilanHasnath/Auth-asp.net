using System.ComponentModel.DataAnnotations;

namespace dotnet.Models;

public class RegisterViewModel
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required, Range(1, 120)]
    public int Age { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required, DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}