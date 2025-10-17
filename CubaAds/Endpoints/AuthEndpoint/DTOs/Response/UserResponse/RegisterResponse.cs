using Types;

namespace CubaAds.Endpoints.AuthEndpoint.DTOs.Response.UserResponse
{
    public class RegisterResponse
    {
        public bool success {  get; set; }
        public string message { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string RefreshToken {  get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }
}
