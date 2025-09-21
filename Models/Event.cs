using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

public class Event
{
    public int Id { get; set; }

    [Required, StringLength(80)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public DateTime Date { get; set; } = DateTime.UtcNow;

    [Required, StringLength(80)]
    public string Location { get; set; } = string.Empty;

    [StringLength(280)]
    public string? Description { get; set; }

    public int Capacity { get; set; } = 100;

    public int RegisteredCount { get; set; }
}
