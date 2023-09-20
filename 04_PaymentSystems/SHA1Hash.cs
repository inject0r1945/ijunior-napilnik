using System.Security.Cryptography;
using System.Text;

namespace PaymentSystems
{
    public class SHA1Hash : IHashingActing
    {
        public string GetHash(string input)
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
