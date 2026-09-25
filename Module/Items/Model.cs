using PhcheabApi.Core;

namespace PhcheabApi.Modules.Items;

public class Item : AuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
