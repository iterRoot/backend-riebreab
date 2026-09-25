using RiebreabApi.Core;
using RiebreabApi.Data;

namespace RiebreabApi.Modules.Videos;

public interface IVideoRepository : IRepository<Video>
{
}

public class VideoRepository : Repository<Video>, IVideoRepository
{
    public VideoRepository(MyDbContext context) : base(context)
    {
    }
}
