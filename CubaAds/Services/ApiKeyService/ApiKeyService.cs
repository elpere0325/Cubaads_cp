


using System.Security.Cryptography;
using System.Text;

namespace CubaAds.Services.ApiKeyService
{
    public static class ApiKeyService
    {
        public static string GenerateApiKey()
        {
            var bytes = RandomNumberGenerator.GetBytes(32);
            return Convert.ToBase64String(bytes)
                .Replace("+","")
                .Replace("/","")
                .Replace("=","");
        }


        public static string HashApiKey(string apiKey)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(apiKey));
            return Convert.ToHexString(bytes);
        }

        public static bool VerifyApiKey(string apiKey, string storedHash) 
        {
            return  HashApiKey(apiKey) == storedHash;
        }
    }
}
