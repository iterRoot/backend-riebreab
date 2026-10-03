using Amazon.Runtime;
using Microsoft.AspNetCore.Mvc;
using RiebreabApi.Core;

namespace RiebreabApi.Modules.Uploads;

public class UploadsController(IUploadService uploadService, ILogger<UploadsController> logger) : MyController
{
    [HttpPost]
    [RequestSizeLimit(10_000_000)]
    [TypeFilter(typeof(ApiKeyFilter))]
    public async Task<IActionResult> Upload(IFormFile? file)
    {
        if (file is null)
        {
            return Required("file");
        }

        try
        {
            var url = await uploadService.UploadAsync(file);
            return Success(new { url });
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            return Error(ex.Message);
        }
        catch (AmazonClientException ex)
        {
            logger.LogError(ex, "Failed to upload image to R2");
            return Error("Image upload failed. Please try again later.");
        }
    }
}
