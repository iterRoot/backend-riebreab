using Microsoft.EntityFrameworkCore;
using PhcheabApi.Core;
using PhcheabApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Phcheab API",
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

builder.Services.AddInjection();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Phcheab API v1");
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
