using RiebreabApi.Core;
using RiebreabApi.Data;

namespace RiebreabApi.Modules.LogIns;
public interface ILogInRepository : IRepository<LogIn>
{
}

public class LogInRepository : Repository<LogIn>, ILogInRepository
{
    public LogInRepository(MyDbContext context) : base(context)
    {
    }
}
