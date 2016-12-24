using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
namespace Networking
{
    public class Encryption
    {
        public string Encrypt(string plaintext, string password, int kdfIterations = 5000)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(plaintext), Encoding.UTF8.GetBytes(password), kdfIterations));
        }

        public string Decrypt(string ciphertext, string password)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(ciphertext), Encoding.UTF8.GetBytes(password)));
        }

        public byte[] Encrypt(byte[] plaintext, byte[] password, int kdfIterations = 5000)
        {
            // using a CSPRNG for IV/salt generation
            var rng = new RNGCryptoServiceProvider();

            // using a 128-bit salt for enough security margin
            var kdfSalt = new byte[16];
            rng.GetBytes(kdfSalt);

            // AES = block size 128 bits always
            var iv = new byte[16];
            rng.GetBytes(iv);

            // using a key derivation function to create the key from the user-specified password
            var kdf = new Rfc2898DeriveBytes(password, kdfSalt, kdfIterations);

            // 256 bits for AES-256
            var masterKey = kdf.GetBytes(32);
            var hmacKey = kdf.GetBytes(64);

            using (var hmac = new HMACSHA256(hmacKey))
            {
                using (var aes = new RijndaelManaged())
                {
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Key = masterKey;
                    aes.IV = iv;
                    var ciphertextBytes = aes.CreateEncryptor().TransformFinalBlock(plaintext, 0, plaintext.Length);
                    var result = new byte[ciphertextBytes.Length + 16 + 16 + 4 + 32];
                    Buffer.BlockCopy(iv, 0, result, 0, 16);
                    Buffer.BlockCopy(kdfSalt, 0, result, 16, 16);
                    Buffer.BlockCopy(BitConverter.GetBytes(kdfIterations), 0, result, 32, 4);
                    Buffer.BlockCopy(ciphertextBytes, 0, result, 36, ciphertextBytes.Length);
                    var hmacHash = hmac.ComputeHash(result, 0, result.Length - 32);
                    Buffer.BlockCopy(hmacHash, 0, result, result.Length - 32, 32);
                    return result;
                }
            }
        }
        public byte[] Decrypt(byte[] input, byte[] password)
        {
            var kdfSalt = new byte[16];
            var iv = new byte[16];
            var ciphertext = new byte[input.Length - 32 - 16 - 16 - 4];
            var hmacBytes = new byte[32];

            Buffer.BlockCopy(input, 0, iv, 0, 16);
            Buffer.BlockCopy(input, 16, kdfSalt, 0, 16);
            var iterations = BitConverter.ToInt32(input, 32);
            Buffer.BlockCopy(input, 36, ciphertext, 0, ciphertext.Length);
            Buffer.BlockCopy(input, 36 + ciphertext.Length, hmacBytes, 0, 32);

            // create KDF with same parameters as used for encryption
            var kdf = new Rfc2898DeriveBytes(password, kdfSalt, iterations);

            // generate the master key (will be same as the one used for encryption if password is correct)
            var masterKey = kdf.GetBytes(32);
            var hmacKey = kdf.GetBytes(64);

            // verify the MAC before decrypt
            using (var hmac = new HMACSHA256(hmacKey))
            {
                var computedHmac = hmac.ComputeHash(input, 0, input.Length - 32);

                bool fail = false;
                for (int i = 0; i < 32; i++)
                {
                    if (computedHmac[i] != hmacBytes[i])
                    {
                        fail = true;
                        break;
                    }
                }
                //if (fail) return null;
                if (fail) throw new CryptographicException("Invalid data");
            }
            using (var aes = new RijndaelManaged())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = masterKey;
                aes.IV = iv;
                var plaintextBytes = aes.CreateDecryptor().TransformFinalBlock(ciphertext, 0, ciphertext.Length);
                return plaintextBytes;
            }

        }
    }
}