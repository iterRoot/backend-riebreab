using System.ComponentModel.DataAnnotations;

namespace RiebreabApi.Modules.Items;

public record ItemResponse(int Id, string Name, string? Description, DateTime CreatedAt, DateTime? UpdatedAt);

public class CreateItemRequest
{
    [Required, MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }
}

public class UpdateItemRequest
{
    [Required, MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }
}
