using System.Security.Cryptography;
using System.Text;

namespace ConnectBridge.Util {
    public class MD5Util {
        private MD5Util() { }

        private static readonly string salt = "@./$^%^%^**)$$%:>";

        public static string GetMD5(string password) {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++) {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();
        }
        
        public static string GetSaltMD5(string md5) {
            return GetMD5(md5 + salt);
        }

        public static bool VerifyPassword(string passwordMD5, string passwordSaltMD5) {
            return passwordSaltMD5.Equals(GetMD5(passwordMD5 + salt));
        }
    }
}