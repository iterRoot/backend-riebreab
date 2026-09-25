using RiebreabApi.Core;
using RiebreabApi.Data;

namespace RiebreabApi.Modules.Events;

public interface IEventRepository : IRepository<Event>
{
}

public class EventRepository : Repository<Event>, IEventRepository
{
    public EventRepository(MyDbContext context) : base(context)
    {
    }
}
