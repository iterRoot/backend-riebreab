using RiebreabApi.Core;

namespace RiebreabApi.Modules.GalleryImages;

public class GalleryImage : AuditableEntity
{
    public string ImgLabel { get; set; } = string.Empty;
}
