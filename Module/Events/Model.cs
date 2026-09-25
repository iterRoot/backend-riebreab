
using System.ComponentModel.DataAnnotations;

namespace RiebreabApi.Modules.Events;


public record EventResponse(int Id, string When, string Title, string TitleKh, string Desc, DateTime CreatedAt, DateTime? UpdatedAt);

public class CreateEventRequest
{
    [Required, MaxLength(50)]
    public string When { get; set; } = string.Empty;

    [Required, MaxLength(300)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(300)]
    public string TitleKh { get; set; } = string.Empty;

    [Required, MaxLength(2000)]
    public string Desc { get; set; } = string.Empty;
}

public class UpdateEventRequest
{
    [Required, MaxLength(50)]
    public string When { get; set; } = string.Empty;

    [Required, MaxLength(300)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(300)]
    public string TitleKh { get; set; } = string.Empty;

    [Required, MaxLength(2000)]
    public string Desc { get; set; } = string.Empty;
}
