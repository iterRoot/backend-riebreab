using RiebreabApi.Core;

namespace RiebreabApi.Modules.Events;

public class Event : AuditableEntity
{
    public string When { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string TitleKh { get; set; } = string.Empty;
    public string Desc { get; set; } = string.Empty;
}
