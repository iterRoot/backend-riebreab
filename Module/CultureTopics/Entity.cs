using RiebreabApi.Core;

namespace RiebreabApi.Modules.CultureTopics;

public class CultureTopic : AuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string ImgLabel { get; set; } = string.Empty;
}

