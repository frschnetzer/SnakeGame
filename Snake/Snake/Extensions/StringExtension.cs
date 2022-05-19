using System.Security.Cryptography;
using System.Text;

namespace Snake.Extensions
{
    public static class StringExtension
    {
        public static string HashString(this string text)
        {
            using var sha = SHA256.Create();

#pragma warning disable CS8603 // Possible null reference return.
            return sha.ComputeHash(Encoding.UTF8.GetBytes(text + "qpoehfradsfsapof")).ToString();
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
