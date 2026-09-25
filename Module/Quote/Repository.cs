using RiebreabApi.Core;
using RiebreabApi.Data;

namespace RiebreabApi.Modules.Quotes;

public interface IQuoteRepository : IRepository<Quote>
{
}

public class QuoteRepository : Repository<Quote>, IQuoteRepository
{
    public QuoteRepository(MyDbContext context) : base(context)
    {
    }
}
