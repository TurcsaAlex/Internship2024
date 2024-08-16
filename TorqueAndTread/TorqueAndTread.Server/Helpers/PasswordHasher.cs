using System.Security.Cryptography;

namespace TorqueAndTread.Server.Helpers
{
    public class PasswordHasher
    {
        private static RandomNumberGenerator rng = RandomNumberGenerator.Create();
        private static readonly int SaltSize = 16;
        private static readonly int HashSize = 32;
        private static readonly int Iterations = 10000;

        public static string HashPassword(string password)
        {
            byte[] salt = new byte[SaltSize];
            rng.GetBytes(salt);
            var key = new Rfc2898DeriveBytes(password, salt, Iterations,HashAlgorithmName.SHA256);

            var hash = key.GetBytes(HashSize);
            var hashBytes=new byte[HashSize+SaltSize];
            Array.Copy(salt, hashBytes, salt.Length);
            Array.Copy(hash, 0, hashBytes, salt.Length, HashSize);

            var base64Hash = Convert.ToBase64String(hashBytes);

            return base64Hash;
        }

        public static bool VerifyPassword(string password, string base64Hash)
        {
            var hashBytes = Convert.FromBase64String(base64Hash);

            var salt = new byte[SaltSize];
            Array.Copy (hashBytes, salt, salt.Length);
            var key = new Rfc2898DeriveBytes(password, salt, Iterations,HashAlgorithmName.SHA256);
            byte[] hash = key.GetBytes(HashSize);
            for (int i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                    return false;
            }
            return true;
        }

    }
}
