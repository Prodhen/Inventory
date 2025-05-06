using System;
using System.Security.Cryptography;
using System.Text;

namespace API.Helper;

public static class PasswordHelper
{
      public static (byte[] Hash, byte[] Salt) CreateHash(string password)
        {
            using var hmac = new HMACSHA512();
            var salt = hmac.Key;
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return (hash, salt);
        }


}
