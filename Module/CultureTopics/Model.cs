
using System.ComponentModel.DataAnnotations;

namespace RiebreabApi.Modules.CultureTopics;

public record CultureTopicResponse(int Id, string Title, string Body, string ImgLabel, DateTime CreatedAt, DateTime? UpdatedAt);

public class CreateCultureTopicRequest
{
    [Required, MaxLength(300)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(3000)]
    public string Body { get; set; } = string.Empty;

    [Required, MaxLength(300)]
    public string ImgLabel { get; set; } = string.Empty;
}

public class UpdateCultureTopicRequest
{
    [Required, MaxLength(300)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(3000)]
    public string Body { get; set; } = string.Empty;

    [Required, MaxLength(300)]
    public string ImgLabel { get; set; } = string.Empty;
}
