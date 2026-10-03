using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using RiebreabApi.Core;
using RiebreabApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Riebreab API",
        Version = "v1"
    });
});

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.Configure<R2Options>(builder.Configuration.GetSection("R2Storage"));
builder.Services.AddSingleton<IAmazonS3>(sp =>
{
    var options = builder.Configuration.GetSection("R2Storage").Get<R2Options>() ?? new R2Options();
    var config = new AmazonS3Config { ForcePathStyle = true };
    if (!string.IsNullOrWhiteSpace(options.AccountId))
    {
        config.ServiceURL = $"https://{options.AccountId}.r2.cloudflarestorage.com";
    }

    return new AmazonS3Client(options.AccessKeyId, options.SecretAccessKey, config);
});

builder.Services.AddInjection();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Riebreab API v1");
    });

    app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.AddMiddleWare();

app.MapControllers();

app.Run();
