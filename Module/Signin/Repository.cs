using RiebreabApi.Core;
using RiebreabApi.Data;

namespace RiebreabApi.Modules.SignIns;

public interface ISignInRepository : IRepository<SignIn>
{
}

public class SignInRepository : Repository<SignIn>, ISignInRepository
{
    public SignInRepository(MyDbContext context) : base(context)
    {
    }
}
