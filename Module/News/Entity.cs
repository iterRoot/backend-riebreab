using System.ComponentModel.DataAnnotations;

namespace RiebreabApi.Modules.News;

public record NewsResponse(int Id, string Category, string Date, string Title, string Excerpt, string ImgLabel, DateTime CreatedAt, DateTime? UpdatedAt);

public class CreateNewsRequest
{
    [Required, MaxLength(100)]
    public string Category { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Date { get; set; } = string.Empty;

    [Required, MaxLength(300)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(2000)]
    public string Excerpt { get; set; } = string.Empty;

    [Required, MaxLength(300)]
    public string ImgLabel { get; set; } = string.Empty;
}

public class UpdateNewsRequest
{
    [Required, MaxLength(100)]
    public string Category { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Date { get; set; } = string.Empty;

    [Required, MaxLength(300)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(2000)]
    public string Excerpt { get; set; } = string.Empty;

    [Required, MaxLength(300)]
    public string ImgLabel { get; set; } = string.Empty;
}
