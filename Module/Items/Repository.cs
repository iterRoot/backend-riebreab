using PhcheabApi.Core;
using PhcheabApi.Data;

namespace PhcheabApi.Modules.Items;

public interface IItemRepository : IRepository<Item>
{
}

public class ItemRepository : Repository<Item>, IItemRepository
{
    public ItemRepository(MyDbContext context) : base(context)
    {
    }
}
