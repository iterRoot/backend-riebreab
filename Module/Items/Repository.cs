using RiebreabApi.Core;
using RiebreabApi.Data;

namespace RiebreabApi.Modules.Items;

public interface IItemRepository : IRepository<Item>
{
}

public class ItemRepository : Repository<Item>, IItemRepository
{
    public ItemRepository(MyDbContext context) : base(context)
    {
    }
}
