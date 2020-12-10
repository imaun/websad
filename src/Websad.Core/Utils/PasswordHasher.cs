using System;

namespace Websad.Core.Utils
{
    public static class PasswordHasher
    {

        public static string GetHashOfString(this string what) {
            const string salt = "imu7hd";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(salt + what);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }
    }
}
