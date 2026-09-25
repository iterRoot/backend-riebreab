
namespace RiebreabApi.Modules.SignIns;



public class CreateSignInRequest
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}

public class UpdateSignInRequest
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}
public class SignInResponse
{
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


}
