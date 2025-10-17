using CubaAds.Context;
using CubaAds.Services.AuthService.Middleware;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder();

builder.Services.AddFastEndpoints();

builder.Services.AddDbContext<DbCubaAdContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//configuracion de autenticacion jwt
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters 
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });


var app = builder.Build();
app.UseMiddleware<ApiKeyAuthMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();
app.Run();

