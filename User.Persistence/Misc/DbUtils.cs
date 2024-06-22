using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Persistence.Misc
{
    internal class DbUtils
    {
        private static readonly string PasswordSalt = "TechnicalTestMandiri!?1qaz2wsx";
        private static readonly string AuthTokenKey = "TechnicalTestMandiriAuthTokenKeys";

        public static string PasswordHash(string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.ASCII.GetBytes(PasswordSalt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
        public static string GenerateAuthToken()
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: DateTime.Now.ToString("yyyyMMddHHmmssffff"),
                salt: Encoding.ASCII.GetBytes(AuthTokenKey),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }
}
