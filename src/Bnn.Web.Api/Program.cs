using Bnn.Data;
using Bnn.Services;
using Bnn.Services.Bananas;
using Bnn.Web.Api;
using Bnn.Web.Api.Extensions;
using Bnn.Web.Api.Infrastructure;
using Bnn.Web.Api.Mapping;
using Bnn.Web.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddData(builder.Configuration)
    .AddServices()
    .AddPresentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.MapGet("/bananas", async (IBananasService service, CancellationToken cancellationToken) =>
{
    var result = await service.GetAllBananas(cancellationToken);
    return result.Match(Results.Ok, CustomResults.Problem);
});

app.MapGet("/bananas/{id:int}", async (int id, IBananasService service, CancellationToken cancellationToken) =>
{
    var result = await service.GetBananaById(id, cancellationToken);
    return result.Match(Results.Ok, CustomResults.Problem);
});

app.MapPost("/bananas",
    async ([FromBody] CreateBananaRequest createBananaRequest, IBananasService service, CancellationToken cancellationToken) =>
    {
        var result = await service.CreateBanana(createBananaRequest.MapToEntity(), cancellationToken);
        return result.Match(Results.Created, CustomResults.Problem);
    });

app.MapPut("/bananas/{id:int}", async ([FromRoute] int id, [FromBody] UpdateBananaRequest updateBanana,
    IBananasService service, CancellationToken cancellationToken) =>
{
    var result = await service.UpdateBanana(updateBanana.MapToEntity(id), cancellationToken);
    return result.Match(Results.NoContent, CustomResults.Problem);
});


app.MapDelete("/bananas/{id:int}", async (int id, IBananasService service, CancellationToken cancellationToken) =>
{
    var result = await service.DeleteBananaById(id, cancellationToken);
    return result.Match(Results.NoContent, CustomResults.Problem);
});

app.UseExceptionHandler();

await app.RunAsync();
