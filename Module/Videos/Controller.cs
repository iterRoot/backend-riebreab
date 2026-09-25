using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiebreabApi.Core;

namespace RiebreabApi.Modules.Videos;

public class VideosController(IVideoRepository repository, IMapper mapper) : MyController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var videos = repository.GetAll()
            .OrderByDescending(v => v.CreatedAt)
            .ToList()
            .Select(mapper.Map<VideoResponse>);

        return Success(videos);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var video = repository.GetSingle(v => v.Id == id);
        return video is null ? Error("Video is not found!") : Success(mapper.Map<VideoResponse>(video));
    }

    [HttpPost]
    public IActionResult Create(CreateVideoRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var video = mapper.Map<Video>(request);
        video.CreatedAt = DateTime.UtcNow;

        repository.Add(video);
        repository.Commit();

        return Success(mapper.Map<VideoResponse>(video));
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, UpdateVideoRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var video = repository.GetSingle(v => v.Id == id);
        if (video is null)
        {
            return Error("Video is not found!");
        }

        video.Title = request.Title;
        video.UpdatedAt = DateTime.UtcNow;

        repository.Update(video);
        repository.Commit();

        return Success(mapper.Map<VideoResponse>(video));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var video = repository.GetSingle(v => v.Id == id);
        if (video is null)
        {
            return Error("Video is not found!");
        }

        repository.Remove(video);
        repository.Commit();

        return Success();
    }
}
