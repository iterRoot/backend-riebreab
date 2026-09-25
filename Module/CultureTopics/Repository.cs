using RiebreabApi.Core;
using RiebreabApi.Data;

namespace RiebreabApi.Modules.CultureTopics;

public interface ICultureTopicRepository : IRepository<CultureTopic>
{
}

public class CultureTopicRepository : Repository<CultureTopic>, ICultureTopicRepository
{
    public CultureTopicRepository(MyDbContext context) : base(context)
    {
    }
}
