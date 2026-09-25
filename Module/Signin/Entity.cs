
using RiebreabApi.Core;
using System.ComponentModel.DataAnnotations;

namespace RiebreabApi.Modules.SignIns;
public class SignIn : AuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}