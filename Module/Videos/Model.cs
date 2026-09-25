using RiebreabApi.Core;

namespace RiebreabApi.Modules.Videos;

public class Video : AuditableEntity
{
    public string Title { get; set; } = string.Empty;
}
