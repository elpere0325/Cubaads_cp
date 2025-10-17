using Types;

namespace CubaAds.Endpoints.AuthEndpoint.DTOs.Response.UserResponse
{
    public class LoginResponse
    {
        public string refreshToken{ get; set; } = string.Empty;
        public DateTime ExpireAt{ get; set; }
        public bool Success { get; set; }
        public string message { get; set; } = string.Empty;
        public Guid id { get; set; }
        public string email { get; set; } = string.Empty;
        public Rol Rol { get; set; }
    }
}
