using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiebreabApi.Core;

namespace RiebreabApi.Modules.SignIns;

public class SignInsController(ISignInRepository repository, IMapper mapper) : MyController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var SignIns = repository.GetAll()
            .OrderByDescending(i => i.CreatedAt)
            .ToList()
            .Select(mapper.Map<SignInResponse>);

        return Success(SignIns);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var SignIn = repository.GetSingle(i => i.Id == id);
        return SignIn is null ? SignInNotFound() : Success(mapper.Map<SignInResponse>(SignIn));
    }

    [HttpPost]
    public IActionResult Create(CreateSignInRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var SignIn = mapper.Map<SignIn>(request);
        SignIn.CreatedAt = DateTime.UtcNow;

        repository.Add(SignIn);
        repository.Commit();

        return Success(mapper.Map<SignInResponse>(SignIn));
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, UpdateSignInRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var SignIn = repository.GetSingle(i => i.Id == id);
        if (SignIn is null)
        {
            return SignInNotFound();
        }

        SignIn.Name = request.Name;
        SignIn.Description = request.Description;
        SignIn.UpdatedAt = DateTime.UtcNow;

        repository.Update(SignIn);
        repository.Commit();

        return Success(mapper.Map<SignInResponse>(SignIn));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var SignIn = repository.GetSingle(i => i.Id == id);
        if (SignIn is null)
        {
            return SignInNotFound();
        }

        repository.Remove(SignIn);
        repository.Commit();

        return Success();
    }
}
