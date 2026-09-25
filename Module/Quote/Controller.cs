using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiebreabApi.Core;

namespace RiebreabApi.Modules.Quotes;

public class QuotesController(IQuoteRepository repository, IMapper mapper) : MyController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var quotes = repository.GetAll()
            .OrderByDescending(q => q.CreatedAt)
            .ToList()
            .Select(mapper.Map<QuoteResponse>);

        return Success(quotes);
    }

    [HttpGet("categories")]
    public IActionResult GetCategories()
    {
        var categories = repository.GetAll()
            .Select(q => q.Category)
            .Distinct()
            .OrderBy(c => c)
            .ToList();

        return Success(categories);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var quote = repository.GetSingle(q => q.Id == id);
        return quote is null ? Error("Quote is not found!") : Success(mapper.Map<QuoteResponse>(quote));
    }

    [HttpPost]
    public IActionResult Create(CreateQuoteRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var quote = mapper.Map<Quote>(request);
        quote.CreatedAt = DateTime.UtcNow;

        repository.Add(quote);
        repository.Commit();

        return Success(mapper.Map<QuoteResponse>(quote));
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, UpdateQuoteRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Error("Invalid request");
        }

        var quote = repository.GetSingle(q => q.Id == id);
        if (quote is null)
        {
            return Error("Quote is not found!");
        }

        quote.Category = request.Category;
        quote.Kh = request.Kh;
        quote.Romanized = request.Romanized;
        quote.En = request.En;
        quote.Meaning = request.Meaning;
        quote.UpdatedAt = DateTime.UtcNow;

        repository.Update(quote);
        repository.Commit();

        return Success(mapper.Map<QuoteResponse>(quote));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var quote = repository.GetSingle(q => q.Id == id);
        if (quote is null)
        {
            return Error("Quote is not found!");
        }

        repository.Remove(quote);
        repository.Commit();

        return Success();
    }
}
