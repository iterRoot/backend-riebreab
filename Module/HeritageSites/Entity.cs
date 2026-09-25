using RiebreabApi.Core;

namespace RiebreabApi.Modules.HeritageSites;

public class HeritageSite : AuditableEntity
{
    public string Year { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string TitleKh { get; set; } = string.Empty;
    public string Desc { get; set; } = string.Empty;
    public string ImgLabel { get; set; } = string.Empty;
}
