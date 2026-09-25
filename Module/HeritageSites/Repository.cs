using RiebreabApi.Core;
using RiebreabApi.Data;

namespace RiebreabApi.Modules.HeritageSites;

public interface IHeritageSiteRepository : IRepository<HeritageSite>
{
}

public class HeritageSiteRepository : Repository<HeritageSite>, IHeritageSiteRepository
{
    public HeritageSiteRepository(MyDbContext context) : base(context)
    {
    }
}
