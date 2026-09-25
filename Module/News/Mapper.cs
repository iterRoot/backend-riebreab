using AutoMapper;

namespace RiebreabApi.Modules.News;

public class NewsMapper : Profile
{
    public NewsMapper()
    {
        CreateMap<News, NewsResponse>();
        CreateMap<CreateNewsRequest, News>();
        CreateMap<UpdateNewsRequest, News>();
    }
}
