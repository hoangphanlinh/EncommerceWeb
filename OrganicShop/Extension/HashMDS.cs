using System.Security.Cryptography;
using System.Text;

namespace OrganicShop.Extension
{
    public static class HashMDS
    {
        public static string ToMDS(this string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sbHash = new StringBuilder();
            foreach(byte b in bHash)
            {
                sbHash.Append(string.Format("{0:x2}",b));
                
            }
            return sbHash.ToString();
        }
    }
}
