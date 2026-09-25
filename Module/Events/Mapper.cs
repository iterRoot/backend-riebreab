using AutoMapper;

namespace RiebreabApi.Modules.Events;

public class EventMapper : Profile
{
    public EventMapper()
    {
        CreateMap<Event, EventResponse>();
        CreateMap<CreateEventRequest, Event>();
        CreateMap<UpdateEventRequest, Event>();
    }
}
