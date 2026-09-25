

using System.ComponentModel.DataAnnotations;

namespace RiebreabApi.Modules.GalleryImages;

public record GalleryImageResponse(int Id, string ImgLabel, DateTime CreatedAt, DateTime? UpdatedAt);

public class CreateGalleryImageRequest
{
    [Required, MaxLength(300)]
    public string ImgLabel { get; set; } = string.Empty;
}

public class UpdateGalleryImageRequest
{
    [Required, MaxLength(300)]
    public string ImgLabel { get; set; } = string.Empty;
}
