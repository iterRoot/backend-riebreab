using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiebreabApi.Core;

namespace RiebreabApi.Modules.LogIns;

public class LogInController(ILogInRepository repository, IMapper mapper) : MyController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var LogIn = repository.GetAll()
            .OrderByDescending(i => i.CreatedAt)
            .ToList()
            .Select(mapper.Map<LogInResponse>);

        return Success(LogIn);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var LogIn = repository.GetSingle(i => i.Id == id);
        return LogIn is null ? LogInNotFound() : Success(mapper.Map<LogInResponse>(LogIn));
    }

    [HttpPost]
    public IActionResult Create(CreateLogInRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var LogIn = mapper.Map<LogIn>(request);
        LogIn.CreatedAt = DateTime.UtcNow;

        repository.Add(LogIn);
        repository.Commit();

        return Success(mapper.Map<LogInResponse>(LogIn));
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, UpdateLogInRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var LogIn = repository.GetSingle(i => i.Id == id);
        if (LogIn is null)
        {
            return LogInNotFound();
        }

        LogIn.Name = request.Name;
        LogIn.Description = request.Description;
        LogIn.UpdatedAt = DateTime.UtcNow;

        repository.Update(LogIn);
        repository.Commit();

        return Success(mapper.Map<LogInResponse>(LogIn));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var LogIn = repository.GetSingle(i => i.Id == id);
        if (LogIn is null)
        {
            return LogInNotFound();
        }

        repository.Remove(LogIn);
        repository.Commit();

        return Success();
    }
}
