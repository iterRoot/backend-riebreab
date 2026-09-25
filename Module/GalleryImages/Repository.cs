using RiebreabApi.Core;
using RiebreabApi.Data;

namespace RiebreabApi.Modules.GalleryImages;

public interface IGalleryImageRepository : IRepository<GalleryImage>
{
}

public class GalleryImageRepository : Repository<GalleryImage>, IGalleryImageRepository
{
    public GalleryImageRepository(MyDbContext context) : base(context)
    {
    }
}
