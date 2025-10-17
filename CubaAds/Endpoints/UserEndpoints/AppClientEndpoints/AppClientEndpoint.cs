using CubaAds.Context;
using CubaAds.Services.ApiKeyService;
using Entities;
using FastEndpoints;
using System;
using CubaAds.Endpoints.AuthEndpoint.DTOs.Requests.AppClientRequest;


public class AppClientEndpoint : Endpoint<AppClientRequest>
{
    private readonly DbCubaAdContext _db;

    public AppClientEndpoint(DbCubaAdContext db)
    {
        _db = db;
    }

    public override void Configure()
    {
        Post("/appclients");
        Roles("Admin", "Anunciante"); 
    }

    public override async Task HandleAsync(AppClientRequest req, CancellationToken ct)
    {
        //generar api key y hashearla
        var plainKey = ApiKeyService.GenerateApiKey();
        var hashedKey = ApiKeyService.HashApiKey(plainKey);

        var app = new AppClient
        {
            app_client_name = req.Name,
            api_key = hashedKey
        };

        _db.AppClients.Add(app);
        await _db.SaveChangesAsync(ct);

        await Send.OkAsync(new
        {
            message = "App client creado",
            apiKey = plainKey
        }, cancellation: ct);
    }
}
