using System.Security.Cryptography;
using System.Text;

namespace PaymentSystems
{
    public static class HashUtils
    {
        public static string GetMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                    stringBuilder.Append(hashBytes[i].ToString("X2"));

                return stringBuilder.ToString();
            }
        }

        public static string GetSHA1Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                int lengthMultiplier = 2;
                StringBuilder stringBuilder = new StringBuilder(hash.Length * lengthMultiplier);
                string stringFormat = "X2";

                foreach (byte hashByte in hash)
                    stringBuilder.Append(hashByte.ToString(stringFormat));

                return stringBuilder.ToString();
            }
        }
    }
}
