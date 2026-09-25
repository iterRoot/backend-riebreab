using RiebreabApi.Core;
using RiebreabApi.Data;

namespace RiebreabApi.Modules.News;

public interface INewsRepository : IRepository<News>
{
}

public class NewsRepository : Repository<News>, INewsRepository
{
    public NewsRepository(MyDbContext context) : base(context)
    {
    }
}
