
namespace RiebreabApi.Modules.LogIns;



public class CreateLogInRequest
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}

public class UpdateLogInRequest
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}
public class LogInResponse
{
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


}
