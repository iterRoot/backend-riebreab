using System.ComponentModel.DataAnnotations;

namespace RiebreabApi.Modules.Quotes;

public record QuoteResponse(int Id, string Category, string Kh, string Romanized, string En, string Meaning, DateTime CreatedAt, DateTime? UpdatedAt);

public class CreateQuoteRequest
{
    [Required, MaxLength(100)]
    public string Category { get; set; } = string.Empty;

    [Required, MaxLength(1000)]
    public string Kh { get; set; } = string.Empty;

    [Required, MaxLength(500)]
    public string Romanized { get; set; } = string.Empty;

    [Required, MaxLength(500)]
    public string En { get; set; } = string.Empty;

    [Required, MaxLength(1000)]
    public string Meaning { get; set; } = string.Empty;
}

public class UpdateQuoteRequest
{
    [Required, MaxLength(100)]
    public string Category { get; set; } = string.Empty;

    [Required, MaxLength(1000)]
    public string Kh { get; set; } = string.Empty;

    [Required, MaxLength(500)]
    public string Romanized { get; set; } = string.Empty;

    [Required, MaxLength(500)]
    public string En { get; set; } = string.Empty;

    [Required, MaxLength(1000)]
    public string Meaning { get; set; } = string.Empty;
}
