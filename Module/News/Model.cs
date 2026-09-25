using RiebreabApi.Core;

namespace RiebreabApi.Modules.News;

public class News : AuditableEntity
{
    public string Category { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Excerpt { get; set; } = string.Empty;
    public string ImgLabel { get; set; } = string.Empty;
}
