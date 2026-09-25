using AutoMapper;

namespace PhcheabApi.Modules.Items;

public class ItemMapper : Profile
{
    public ItemMapper()
    {
        CreateMap<Item, ItemResponse>();
        CreateMap<CreateItemRequest, Item>();
        CreateMap<UpdateItemRequest, Item>();
    }
}
