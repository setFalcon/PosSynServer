using System.Security.Cryptography;
using System.Text;

namespace SQLTest.util {
    public class MD5Util {
        private MD5Util() { }

        public static string GetPasswordMD5(string password) {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++) {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();
        }

        public static bool VerifyPassword(string inputPassword, string actualPassword) {
            string inputPasswordMd5 = inputPassword;
            return inputPasswordMd5.Equals(actualPassword);
        }
    }
}