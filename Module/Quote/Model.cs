using RiebreabApi.Core;

namespace RiebreabApi.Modules.Quotes;

public class Quote : AuditableEntity
{
    public string Category { get; set; } = string.Empty;
    public string Kh { get; set; } = string.Empty;
    public string Romanized { get; set; } = string.Empty;
    public string En { get; set; } = string.Empty;
    public string Meaning { get; set; } = string.Empty;
}
