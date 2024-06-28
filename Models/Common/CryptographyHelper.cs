using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace Forum.Models.Common
{
    public class CryptographyHelper
    {
        #region PROPERTIES
        private static readonly Random Random = new Random();
        private static readonly char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

        private static string _ApplicationSalt = null;
        public static string ApplicationSalt
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_ApplicationSalt))
                {
                    _ApplicationSalt = "TjtzgRBx4pMK1z1QNy6Y5oITg3TkSY";
                }

                return _ApplicationSalt;
            }
        }
        #endregion PROPERTIES



        #region PUBLIC
        public static string GenerateSalt()
        {
            var token = new StringBuilder();
            for(int i = 0; i < 8; i++)
            {
                token.Append(Alphabet[Random.Next(Alphabet.Length)]);
            }
            return token.ToString();
        }

        public static string HashPassword(string passwordSalt, string password)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                Byte[] data = Encoding.UTF8.GetBytes(ApplicationSalt + password + passwordSalt);
                Byte[] result = sha512.ComputeHash(data);

                sha512.Clear();

                return Convert.ToBase64String(result);
            }
        }
        #endregion PUBLIC
    }
}
