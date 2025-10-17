using CubaAds.Context;
using System.Text;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using CubaAds.Services.ApiKeyService;



namespace CubaAds.Services.AuthService.Middleware
{
    public class ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _next;


        public ApiKeyAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, DbCubaAdContext db)
        {
            if (!context.Request.Headers.TryGetValue("X-Api-Key", out var extractedKey))
            {
                await _next(context);
                return;
            }

            string hashedKey = ApiKeyService.ApiKeyService.HashApiKey(extractedKey!);


            var app = await db.AppClients.FirstOrDefaultAsync(ac => ac.api_key == hashedKey);
            if (app == null) 
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid Api Key");
                return;
            }

            context.Items["AppClient"] = app;
            await _next(context);
        }

    }
}
