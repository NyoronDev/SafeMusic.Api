using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Safy.AppService.Infrastructure.Contracts;

namespace Safy.AppService.Infrastructure.Services
{
    public class HashService : IHashService
    {
        public byte[] CreateSalt()
        {
            // generate a 128-bit salt using a secure PRNG
            var salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public string CreateHash(string value, byte[] salt)
        {            
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            var hashedValue = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: value,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashedValue;
        }
    }
}
