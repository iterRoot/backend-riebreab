using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiebreabApi.Core;

namespace RiebreabApi.Modules.Events;

public class EventsController(IEventRepository repository, IMapper mapper) : MyController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var events = repository.GetAll()
            .OrderByDescending(e => e.CreatedAt)
            .ToList()
            .Select(mapper.Map<EventResponse>);

        return Success(events);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var ev = repository.GetSingle(e => e.Id == id);
        return ev is null ? Error("Event is not found!") : Success(mapper.Map<EventResponse>(ev));
    }

    [HttpPost]
    public IActionResult Create(CreateEventRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var ev = mapper.Map<Event>(request);
        ev.CreatedAt = DateTime.UtcNow;

        repository.Add(ev);
        repository.Commit();

        return Success(mapper.Map<EventResponse>(ev));
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, UpdateEventRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var ev = repository.GetSingle(e => e.Id == id);
        if (ev is null)
        {
            return Error("Event is not found!");
        }

        ev.When = request.When;
        ev.Title = request.Title;
        ev.TitleKh = request.TitleKh;
        ev.Desc = request.Desc;
        ev.UpdatedAt = DateTime.UtcNow;

        repository.Update(ev);
        repository.Commit();

        return Success(mapper.Map<EventResponse>(ev));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var ev = repository.GetSingle(e => e.Id == id);
        if (ev is null)
        {
            return Error("Event is not found!");
        }

        repository.Remove(ev);
        repository.Commit();

        return Success();
    }
}
