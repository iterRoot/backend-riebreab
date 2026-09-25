using AutoMapper;

namespace RiebreabApi.Modules.GalleryImages;

public class GalleryImageMapper : Profile
{
    public GalleryImageMapper()
    {
        CreateMap<GalleryImage, GalleryImageResponse>();
        CreateMap<CreateGalleryImageRequest, GalleryImage>();
        CreateMap<UpdateGalleryImageRequest, GalleryImage>();
    }
}
