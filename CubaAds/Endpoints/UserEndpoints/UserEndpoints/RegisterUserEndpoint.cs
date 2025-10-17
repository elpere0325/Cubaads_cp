using CubaAds.Context;
using CubaAds.Endpoints.AuthEndpoint.DTOs.Requests.UserRequests;
using CubaAds.Endpoints.AuthEndpoint.DTOs.Response.UserResponse;
using CubaAds.Services.PasswordHasher;
using CubaAds.Services.TokenServices;
using Entities;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using CubaAds.Services.AuthService.Validators;



namespace CubaAds.Endpoints.UserEndpoints.UserEndpoints
{

    public class RegisterUserEndpoint : Endpoint<RegistUserRequest, Results<Ok<RegisterResponse>, BadRequest<RegisterResponse>>>
    {
        private readonly DbCubaAdContext _db;
        private readonly TokenService _tokenService;

        public RegisterUserEndpoint(DbCubaAdContext db, TokenService tokenService)
        {
            _db = db;
            _tokenService = tokenService;
        }

        public override void Configure()
        {
            Post("auth/register");
            AllowAnonymous();
        }

        public override async Task<Results<Ok<RegisterResponse>, BadRequest<RegisterResponse>>> HandleAsync(RegistUserRequest req, CancellationToken ct)
        {
            //verificando si el email ya existe
            if (await _db.Users.AnyAsync(u => u.email == req.email, ct))
            {
                return TypedResults.BadRequest(new RegisterResponse
                {
                    success = false,
                    message = "El email ya existe"
                });
            }

            //generando refresh token para el nuevo usuario
            var RefreshToken = _tokenService.GenerateRefreshToken();
            var RefreshTokenExpire = DateTime.UtcNow.AddDays(3);


            var user = new User
            {
                email = req.email,
                password = PasswordHasher.HashPassword(req.password),
                rol = req.rol,
                refresh_token = RefreshToken,
                refresh_token_expire = RefreshTokenExpire,

            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync(ct);


            return TypedResults.Ok(new RegisterResponse
            {
                success = true,
                message = "El usuario ha sido creado correctamente",
                UserId = user.id,
                Email = req.email,
                RefreshToken = RefreshToken,
                Rol = user.rol.ToString(),
            });

           
        }
    }
}
