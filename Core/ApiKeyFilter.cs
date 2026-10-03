using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RiebreabApi.Core;

// Requires the "X-Api-Key" header to match the "Uploads:ApiKey" setting.
// An empty or missing setting rejects every request, so the endpoint fails closed.
public class ApiKeyFilter(IConfiguration configuration) : IActionFilter
{
    private const string HeaderName = "X-Api-Key";

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var expected = configuration["Uploads:ApiKey"];
        if (string.IsNullOrEmpty(expected) ||
            !context.HttpContext.Request.Headers.TryGetValue(HeaderName, out var provided))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var expectedBytes = Encoding.UTF8.GetBytes(expected);
        var providedBytes = Encoding.UTF8.GetBytes(provided.ToString());
        if (!CryptographicOperations.FixedTimeEquals(expectedBytes, providedBytes))
        {
            context.Result = new UnauthorizedResult();
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}
