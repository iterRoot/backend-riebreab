using AutoMapper;

namespace RiebreabApi.Modules.CultureTopics;

public class CultureTopicMapper : Profile
{
    public CultureTopicMapper()
    {
        CreateMap<CultureTopic, CultureTopicResponse>();
        CreateMap<CreateCultureTopicRequest, CultureTopic>();
        CreateMap<UpdateCultureTopicRequest, CultureTopic>();
    }
}
