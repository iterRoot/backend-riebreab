using AutoMapper;

namespace RiebreabApi.Modules.HeritageSites;

public class HeritageSiteMapper : Profile
{
    public HeritageSiteMapper()
    {
        CreateMap<HeritageSite, HeritageSiteResponse>();
        CreateMap<CreateHeritageSiteRequest, HeritageSite>();
        CreateMap<UpdateHeritageSiteRequest, HeritageSite>();
    }
}
