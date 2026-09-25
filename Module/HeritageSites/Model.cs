
using System.ComponentModel.DataAnnotations;

namespace RiebreabApi.Modules.HeritageSites;

public record HeritageSiteResponse(int Id, string Year, string Title, string TitleKh, string Desc, string ImgLabel, DateTime CreatedAt, DateTime? UpdatedAt);

public class CreateHeritageSiteRequest
{
    [Required, MaxLength(20)]
    public string Year { get; set; } = string.Empty;

    [Required, MaxLength(300)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(300)]
    public string TitleKh { get; set; } = string.Empty;

    [Required, MaxLength(2000)]
    public string Desc { get; set; } = string.Empty;

    [Required, MaxLength(300)]
    public string ImgLabel { get; set; } = string.Empty;
}

public class UpdateHeritageSiteRequest
{
    [Required, MaxLength(20)]
    public string Year { get; set; } = string.Empty;

    [Required, MaxLength(300)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(300)]
    public string TitleKh { get; set; } = string.Empty;

    [Required, MaxLength(2000)]
    public string Desc { get; set; } = string.Empty;

    [Required, MaxLength(300)]
    public string ImgLabel { get; set; } = string.Empty;
}
