using System.ComponentModel.DataAnnotations;
using RiebreabApi.Core;

namespace RiebreabApi.Modules.LogIns;


public class LogIn : AuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}