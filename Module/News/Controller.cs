using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiebreabApi.Core;

namespace RiebreabApi.Modules.News;

public class NewsController(INewsRepository repository, IMapper mapper) : MyController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var news = repository.GetAll()
            .OrderByDescending(n => n.CreatedAt)
            .ToList()
            .Select(mapper.Map<NewsResponse>);

        return Success(news);
    }

    [HttpGet("categories")]
    public IActionResult GetCategories()
    {
        var categories = repository.GetAll()
            .Select(n => n.Category)
            .Distinct()
            .OrderBy(c => c)
            .ToList();

        return Success(categories);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var news = repository.GetSingle(n => n.Id == id);
        return news is null ? Error("News is not found!") : Success(mapper.Map<NewsResponse>(news));
    }

    [HttpPost]
    public IActionResult Create(CreateNewsRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var news = mapper.Map<News>(request);
        news.CreatedAt = DateTime.UtcNow;

        repository.Add(news);
        repository.Commit();

        return Success(mapper.Map<NewsResponse>(news));
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, UpdateNewsRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var news = repository.GetSingle(n => n.Id == id);
        if (news is null)
        {
            return Error("News is not found!");
        }

        news.Category = request.Category;
        news.Date = request.Date;
        news.Title = request.Title;
        news.Excerpt = request.Excerpt;
        news.ImgLabel = request.ImgLabel;
        news.UpdatedAt = DateTime.UtcNow;

        repository.Update(news);
        repository.Commit();

        return Success(mapper.Map<NewsResponse>(news));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var news = repository.GetSingle(n => n.Id == id);
        if (news is null)
        {
            return Error("News is not found!");
        }

        repository.Remove(news);
        repository.Commit();

        return Success();
    }
}
