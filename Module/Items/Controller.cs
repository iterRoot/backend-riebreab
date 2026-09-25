using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiebreabApi.Core;

namespace RiebreabApi.Modules.Items;

public class ItemsController(IItemRepository repository, IMapper mapper) : MyController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var items = repository.GetAll()
            .OrderByDescending(i => i.CreatedAt)
            .ToList()
            .Select(mapper.Map<ItemResponse>);

        return Success(items);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var item = repository.GetSingle(i => i.Id == id);
        return item is null ? ItemNotFound() : Success(mapper.Map<ItemResponse>(item));
    }

    [HttpPost]
    public IActionResult Create(CreateItemRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var item = mapper.Map<Item>(request);
        item.CreatedAt = DateTime.UtcNow;

        repository.Add(item);
        repository.Commit();

        return Success(mapper.Map<ItemResponse>(item));
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, UpdateItemRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var item = repository.GetSingle(i => i.Id == id);
        if (item is null)
        {
            return ItemNotFound();
        }

        item.Name = request.Name;
        item.Description = request.Description;
        item.UpdatedAt = DateTime.UtcNow;

        repository.Update(item);
        repository.Commit();

        return Success(mapper.Map<ItemResponse>(item));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var item = repository.GetSingle(i => i.Id == id);
        if (item is null)
        {
            return ItemNotFound();
        }

        repository.Remove(item);
        repository.Commit();

        return Success();
    }
}
