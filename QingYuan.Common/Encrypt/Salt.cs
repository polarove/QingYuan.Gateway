using System.Security.Cryptography;

namespace QingYuan.Common.Encrypt
{
    public class Salt
    {
        public static string Generate(int size = 16)
        {
            var bytes = new byte[size];
            RandomNumberGenerator.Fill(bytes); // 用随机数据填充字节数组
            byte[ ] hashBytes = SHA256.HashData(bytes);
            string hashString = Convert.ToHexString(hashBytes).ToLower();
            return hashString;
        }
    }
}
