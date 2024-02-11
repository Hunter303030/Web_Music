using System.Security.Cryptography;
using System.Text;

namespace Web_Music_v3.Services
{
    public class Hash
    {
        public string GetHash(string password)
        {
            var md5 = MD5.Create();

            var hash = md5.ComputeHash
                (
                    Encoding.UTF8.GetBytes(password)
                );
            return Convert.ToBase64String(hash);
        }
    }
}
