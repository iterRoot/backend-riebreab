using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiebreabApi.Core;

namespace RiebreabApi.Modules.CultureTopics;

public class CultureTopicsController(ICultureTopicRepository repository, IMapper mapper) : MyController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var topics = repository.GetAll()
            .OrderByDescending(c => c.CreatedAt)
            .ToList()
            .Select(mapper.Map<CultureTopicResponse>);

        return Success(topics);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var topic = repository.GetSingle(c => c.Id == id);
        return topic is null ? Error("CultureTopic is not found!") : Success(mapper.Map<CultureTopicResponse>(topic));
    }

    [HttpPost]
    public IActionResult Create(CreateCultureTopicRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var topic = mapper.Map<CultureTopic>(request);
        topic.CreatedAt = DateTime.UtcNow;

        repository.Add(topic);
        repository.Commit();

        return Success(mapper.Map<CultureTopicResponse>(topic));
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, UpdateCultureTopicRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var topic = repository.GetSingle(c => c.Id == id);
        if (topic is null)
        {
            return Error("CultureTopic is not found!");
        }

        topic.Title = request.Title;
        topic.Body = request.Body;
        topic.ImgLabel = request.ImgLabel;
        topic.UpdatedAt = DateTime.UtcNow;

        repository.Update(topic);
        repository.Commit();

        return Success(mapper.Map<CultureTopicResponse>(topic));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var topic = repository.GetSingle(c => c.Id == id);
        if (topic is null)
        {
            return Error("CultureTopic is not found!");
        }

        repository.Remove(topic);
        repository.Commit();

        return Success();
    }
}
