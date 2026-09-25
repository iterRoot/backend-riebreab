using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiebreabApi.Core;

namespace RiebreabApi.Modules.HeritageSites;

public class HeritageSitesController(IHeritageSiteRepository repository, IMapper mapper) : MyController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var sites = repository.GetAll()
            .OrderByDescending(h => h.CreatedAt)
            .ToList()
            .Select(mapper.Map<HeritageSiteResponse>);

        return Success(sites);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var site = repository.GetSingle(h => h.Id == id);
        return site is null ? Error("HeritageSite is not found!") : Success(mapper.Map<HeritageSiteResponse>(site));
    }

    [HttpPost]
    public IActionResult Create(CreateHeritageSiteRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var site = mapper.Map<HeritageSite>(request);
        site.CreatedAt = DateTime.UtcNow;

        repository.Add(site);
        repository.Commit();

        return Success(mapper.Map<HeritageSiteResponse>(site));
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, UpdateHeritageSiteRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var site = repository.GetSingle(h => h.Id == id);
        if (site is null)
        {
            return Error("HeritageSite is not found!");
        }

        site.Year = request.Year;
        site.Title = request.Title;
        site.TitleKh = request.TitleKh;
        site.Desc = request.Desc;
        site.ImgLabel = request.ImgLabel;
        site.UpdatedAt = DateTime.UtcNow;

        repository.Update(site);
        repository.Commit();

        return Success(mapper.Map<HeritageSiteResponse>(site));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var site = repository.GetSingle(h => h.Id == id);
        if (site is null)
        {
            return Error("HeritageSite is not found!");
        }

        repository.Remove(site);
        repository.Commit();

        return Success();
    }
}
