using System.ComponentModel.DataAnnotations;

namespace RiebreabApi.Modules.Videos;

public record VideoResponse(int Id, string Title, DateTime CreatedAt, DateTime? UpdatedAt);

public class CreateVideoRequest
{
    [Required, MaxLength(300)]
    public string Title { get; set; } = string.Empty;
}

public class UpdateVideoRequest
{
    [Required, MaxLength(300)]
    public string Title { get; set; } = string.Empty;
}
