using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RiebreabApi.Core;

namespace RiebreabApi.Modules.Uploads;

public interface IUploadService
{
    Task<string> UploadAsync(IFormFile file);
}

public class UploadService : IUploadService
{
    private static readonly HashSet<string> AllowedContentTypes = new(StringComparer.OrdinalIgnoreCase)
    {
        "image/jpeg", "image/png", "image/webp", "image/gif"
    };

    private const long MaxFileSizeBytes = 10 * 1024 * 1024;

    private readonly IAmazonS3 _s3Client;
    private readonly R2Options _options;

    public UploadService(IAmazonS3 s3Client, IOptions<R2Options> options)
    {
        _s3Client = s3Client;
        _options = options.Value;
    }

    public async Task<string> UploadAsync(IFormFile file)
    {
        if (string.IsNullOrWhiteSpace(_options.BucketName) || string.IsNullOrWhiteSpace(_options.PublicBaseUrl))
        {
            throw new InvalidOperationException("Image storage is not configured yet. Set R2Storage settings (see appsettings.json).");
        }

        if (file.Length == 0)
        {
            throw new ArgumentException("File is empty.");
        }

        if (file.Length > MaxFileSizeBytes)
        {
            throw new ArgumentException("File exceeds the 10MB size limit.");
        }

        if (!AllowedContentTypes.Contains(file.ContentType))
        {
            throw new ArgumentException("Only JPEG, PNG, WEBP, or GIF images are allowed.");
        }

        var extension = Path.GetExtension(file.FileName);
        var key = $"images/{Guid.NewGuid()}{extension}";

        await using var stream = file.OpenReadStream();
        var request = new PutObjectRequest
        {
            BucketName = _options.BucketName,
            Key = key,
            InputStream = stream,
            ContentType = file.ContentType,
            DisablePayloadSigning = true
        };

        await _s3Client.PutObjectAsync(request);

        return $"{_options.PublicBaseUrl.TrimEnd('/')}/{key}";
    }
}
