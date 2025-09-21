using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

public class Registration
{
    [Required, StringLength(40)]
    public string Name { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Range(1, 10)]
    public int Tickets { get; set; } = 1;
}
