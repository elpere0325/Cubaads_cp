using Isopoh.Cryptography.Argon2;
using System.Text;


namespace CubaAds.Services.PasswordHasher
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            return Argon2.Hash(password);
        }

        public static bool Verify(string hash, string password)
        {
            return Argon2.Verify(hash, password);
        }
    }
}

