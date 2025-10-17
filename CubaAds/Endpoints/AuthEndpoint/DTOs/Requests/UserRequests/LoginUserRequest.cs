namespace CubaAds.Endpoints.AuthEndpoint.DTOs.Requests.UserRequests
{
    public class LoginUserRequest
    {
        public string email { get; set; } = default!;
        public string password { get; set; } = default!;
    }
}
