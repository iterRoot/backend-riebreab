using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiebreabApi.Core;

namespace RiebreabApi.Modules.GalleryImages;

public class GalleryImagesController(IGalleryImageRepository repository, IMapper mapper) : MyController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var images = repository.GetAll()
            .OrderByDescending(g => g.CreatedAt)
            .ToList()
            .Select(mapper.Map<GalleryImageResponse>);

        return Success(images);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var image = repository.GetSingle(g => g.Id == id);
        return image is null ? Error("GalleryImage is not found!") : Success(mapper.Map<GalleryImageResponse>(image));
    }

    [HttpPost]
    public IActionResult Create(CreateGalleryImageRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var image = mapper.Map<GalleryImage>(request);
        image.CreatedAt = DateTime.UtcNow;

        repository.Add(image);
        repository.Commit();

        return Success(mapper.Map<GalleryImageResponse>(image));
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, UpdateGalleryImageRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var image = repository.GetSingle(g => g.Id == id);
        if (image is null)
        {
            return Error("GalleryImage is not found!");
        }

        image.ImgLabel = request.ImgLabel;
        image.UpdatedAt = DateTime.UtcNow;

        repository.Update(image);
        repository.Commit();

        return Success(mapper.Map<GalleryImageResponse>(image));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var image = repository.GetSingle(g => g.Id == id);
        if (image is null)
        {
            return Error("GalleryImage is not found!");
        }

        repository.Remove(image);
        repository.Commit();

        return Success();
    }
}
