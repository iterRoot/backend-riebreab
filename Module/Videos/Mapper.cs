using AutoMapper;

namespace RiebreabApi.Modules.Videos;

public class VideoMapper : Profile
{
    public VideoMapper()
    {
        CreateMap<Video, VideoResponse>();
        CreateMap<CreateVideoRequest, Video>();
        CreateMap<UpdateVideoRequest, Video>();
    }
}
