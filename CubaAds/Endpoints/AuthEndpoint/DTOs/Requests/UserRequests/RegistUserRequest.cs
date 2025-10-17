using Types;

namespace CubaAds.Endpoints.AuthEndpoint.DTOs.Requests.UserRequests 
{
    public class RegistUserRequest
    {
        public string email { get; set; } = default!;
        public string password { get; set; } = default!;
        public Rol rol { get; set; } = Rol.Anunciante;

    }
}
