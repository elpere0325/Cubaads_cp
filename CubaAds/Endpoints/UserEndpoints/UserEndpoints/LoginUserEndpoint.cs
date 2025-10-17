using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using CubaAds.Context;
using CubaAds.Services.TokenServices;
using CubaAds.Services.PasswordHasher;
using CubaAds.Endpoints.AuthEndpoint.DTOs.Requests.UserRequests;
using Microsoft.AspNetCore.Http.HttpResults;
using CubaAds.Endpoints.AuthEndpoint.DTOs.Response.UserResponse;



namespace CubaAds.Endpoints.UserEndpoints.UserEndpoints
{
    public class LoginUserEndpoint : Endpoint<LoginUserRequest, Results<Ok<LoginResponse>,BadRequest<LoginResponse>>>
    {
        private readonly DbCubaAdContext _db;
        private readonly TokenService _tokenService;


        public LoginUserEndpoint(DbCubaAdContext db, TokenService tokenService)
        {
            _db = db;
            _tokenService = tokenService;
        }


        public override void Configure()
        {
            Post("/auth/login");
            AllowAnonymous();
        }

        public override async Task <Results<Ok<LoginResponse>, BadRequest<LoginResponse>>> HandleAsync(LoginUserRequest req, CancellationToken ct)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.email == req.email, ct); 

            //verificando si el usuario existe y si la contraseña es correcta

            if (user == null || !PasswordHasher.Verify(user.password, req.password))
            {
                return TypedResults.BadRequest(new LoginResponse
                {
                    message = "Invalid email or password"
                });
            }

            //generando nuevo refreshtoken para el usuario logueado
            var RefreshToken = _tokenService.GenerateRefreshToken();
            var RefreshTokenExpire = DateTime.UtcNow.AddDays(3);
            user.refresh_token = RefreshToken;
            user.refresh_token_expire = RefreshTokenExpire;

            await _db.SaveChangesAsync();

            return TypedResults.Ok (new LoginResponse
            {
                refreshToken = RefreshToken,
                ExpireAt = RefreshTokenExpire,
                Success = true,
                message = "Login success",
                Rol = user.rol,
            });
        }

        
    }
}
